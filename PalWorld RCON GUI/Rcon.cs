using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalWorldR
{
    internal class Rcon
    {
        private static TcpClient client;
        private static NetworkStream networkStream;

        /// <summary>RCONパケットヘッダ</summary>
        /// <remarks>0.1.5.1バージョンですべて00で埋まっている</remarks>
        private const int PACKET_HEADER = 11;

        static Form form;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form1();
            Application.Run(form);

            AppDomain.CurrentDomain.ProcessExit += ProcessExit;
        }

        /// <summary>RCON接続</summary>
        /// <param name="address">アドレス</param>
        /// <param name="port">ポート番号</param>
        /// <param name="password">パスワード</param>
        public static async Task<string> Connect(string address, string port, string password)
        {
            client = new TcpClient();

            try
            {
                await client.ConnectAsync(address, int.Parse(port));
            }
            catch(Exception)
            {
                return "接続に失敗しました";
            }

            if (!client.Connected)
            {
                DisposeClient();
                return "接続に失敗しました";
            }

            bool isAuth = await Auth(password);
            if (isAuth)
            {
                var output = await GetServerInfo();
                var message = $"接続に成功しました\r\n{output}";
                return message;
            }

            DisposeClient();
            return "認証に失敗しました";
        }

        /// <summary>サーバ情報を取得</summary>
        /// <param name="keep">接続維持</param>
        public static async Task<string> GetServerInfo()
        {
            string command = $"info";
            string message = await ExecuteCommand(command);
            return message;
        }

        /// <summary>接続中のプレイヤを取得</summary>
        public static async Task<string> GetPlayers()
        {
            string command = $"showplayers";
            string message = await ExecuteCommand(command);

            bool isSuccess = message.IndexOf("失敗") == -1;
            if (!isSuccess) { return message; }

            var players = message.Split('\n');

            var sb = new StringBuilder();
            int skipedHeader = 1;
            for (int i = skipedHeader; i < players.Count(); i++)
            {
                string player = players[i];
                sb.AppendLine($"{i}:{player}");
            }

            string playerList = sb.ToString();
            return playerList;
        }

        /// <summary>サーバにメッセージを送信</summary>
        /// <param name="text">サーバに表示するメッセージ</param>
        public static async Task<string> Broadcast(string text)
        {
            string command = $"broadcast {text}";
            string message = await ExecuteCommand(command);
            return message;
        }

        /// <summary>接続維持のため再読み込み</summary>
        public static async Task Reload()
        {
            await GetServerInfo();
        }

        /// <summary>シャットダウン系コマンドを実行</summary>
        /// <param name="shutdownTime"></param>
        /// <param name="broadcastMessage"></param>
        /// <param name="isDoExit">DoExitコマンドを実行するか</param>
        public static async Task<string> ShutDown(string shutdownTime = "300", string broadcastMessage = "Reboot_after_5_minutes", bool isDoExit = false)
        {
            string command = isDoExit ? "doexit" : $"shutdown {shutdownTime} {broadcastMessage}";
            string message = await ExecuteCommand(command);
            return message;
        }

        /// <summary>バン/キックコマンドを実行</summary>
        /// <param name="playerid">PID/SteamID</param>
        /// <param name="isBanCommand">バンを実行するか</param>
        public static async Task<string> Banishment(string playerid, bool isBanCommand = false)
        {
            string command = isBanCommand ? $"banplayer {playerid}" : $"kickplayer {playerid}";
            string message = await ExecuteCommand(command);
            return message;
        }

        /// <summary>自由書式のコマンドを実行</summary>
        public static async Task<string> CustomCommand(string text)
        {
            string message = await ExecuteCommand(text);
            return message;
        }

        /// <summary>認証</summary>
        /// <param name="password">RCONパスワード</param>
        /// <returns>認証が成功したか</returns>
        private static async Task<bool> Auth(string password)
        {
            try
            {
                networkStream = client.GetStream();

                Pck auth = new Pck(0xf5, PacketType.AUTH, Encoding.ASCII.GetBytes(password));
                networkStream.Write(auth.ToBytes(), 0, auth.Length);

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                bool isAuth = data[3] == 0xf5;
                return isAuth;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>RCONコマンドを実行</summary>
        /// <param name="command">RCONコマンド</param>
        /// <returns>RCONレスポンス</returns>
        private static async Task<string> ExecuteCommand(string command)
        {
            if(client == null || networkStream == null || command == null) { return "失敗しました"; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }

                Pck pck = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes(command));
                networkStream.Write(pck.ToBytes(), 0, pck.Length);

                int size = networkStream.ReadByte();
                var data = new byte[size];
                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch(Exception)
            {
                return "失敗しました";
            }
        }

        [Serializable]
        public class Pck
        {
            public int Size;
            public int ID;
            public PacketType Type;
            public byte[] Body;

            public Pck(int id, PacketType type, byte[] body)
            {
                ID = id;
                Type = type;
                Body = body.Concat(new byte[] { 0x00, 0x00 }).ToArray();
                Size = body.Length + 10;
            }

            internal byte[] ToBytes()
            {
                byte[] res = new byte[Size + 4];
                BitConverter.GetBytes(Size).CopyTo(res, 0);
                BitConverter.GetBytes(ID).CopyTo(res, 4);
                BitConverter.GetBytes((int)Type).CopyTo(res, 8);
                Body.CopyTo(res, 12);
                return res;
            }

            internal int Length => Body.Length + 12;
        }

        public enum PacketType : int
        {
            RESPONSE_VALUE = 0,
            AUTH_RESPONSE = 2,
            EXECCOMMAND = 2,
            AUTH = 3
        }

        public static void ProcessExit(object sender, EventArgs ea)
        {
            DisposeClient();
        }

        /// <summary>Clientを破棄</summary>
        private static void DisposeClient()
        {
            if (client == null) { return; }
            if (client.Connected) { client.GetStream().Close(); }

            client.Dispose();
            client = null;
        }
    }
}