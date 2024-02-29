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

        public static async Task<string> Connect(string address, string port, string pass)
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

            networkStream = client.GetStream();

            Pck auth = new Pck(0xf5, PacketType.AUTH, Encoding.ASCII.GetBytes(pass));

            networkStream.Write(auth.ToBytes(), 0, auth.Length);

            int size = networkStream.ReadByte();
            byte[] data = new byte[size];

            await networkStream.ReadAsync(data, 0, size);

            bool isSuccessConnect = data[3] == 0xf5;
            if (isSuccessConnect)
            {
                var output = await SInfo();
                var message = $"接続に成功しました\r\n{output}";
                return message;
            }

            DisposeClient();
            return "認証に失敗しました";
        }

        public static async Task<string> SInfo(bool keep = false)
        {
            if (client == null) { return ""; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck pck = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("info"));
                networkStream.Write(pck.ToBytes(), 0, pck.Length);

                int size = networkStream.ReadByte();
                var data = new byte[size];
                await networkStream.ReadAsync(data, 0, size);

                if (keep) { return ""; }
                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch
            {
                return "取得に失敗しました";
            }
        }

        public static async Task<string> GetPlayers()
        {
            const string FAILED_MESSAGE = "取得に失敗しました";
            if (client == null) { return FAILED_MESSAGE; }
            if (networkStream == null) { return ""; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck pck = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("showplayers"));
                networkStream.Write(pck.ToBytes(), 0, pck.Length);

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                var players = responseMessage.Split('\n');

                var sb = new StringBuilder();
                int skipedHeader = 1;
                for (int i = skipedHeader; i < players.Count(); i++)
                {
                    string player = players[i];
                    sb.AppendLine($"{i}:{player}");
                }

                string message = sb.ToString();
                return message;
            }
            catch (Exception)
            {
                return FAILED_MESSAGE;
            }
        }

        public static async Task<string> Broadcast(string text)
        {
            const string FAILED_MESSAGE = "失敗しました";
            if (client == null) { return FAILED_MESSAGE; }
            if (networkStream == null) { return ""; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck packet = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.UTF8.GetBytes("broadcast " + text));
                networkStream.Write(packet.ToBytes(), 0, packet.Length);

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch (Exception)
            {
                return FAILED_MESSAGE;
            }
        }

        public static async Task Reload()
        {
            if (client == null || !client.Connected) { return; }
            
            await SInfo(true);
        }

        public static async Task<string> ShutDown(string time, string text, bool flg = false)
        {
            const string FAILED_MESSAGE = "失敗しました";
            if (client == null) { return FAILED_MESSAGE; }
            if (networkStream == null) { return ""; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck packet;
                if (flg)
                {
                    packet = new Pck(0x2f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("doexit"));
                    networkStream.Write(packet.ToBytes(), 0, packet.Length);
                }
                else
                {
                    packet = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("shutdown " + time + " " + text));
                    networkStream.Write(packet.ToBytes(), 0, packet.Length);
                }

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch (Exception)
            {
                return FAILED_MESSAGE;
            }
        }

        public static async Task<string> Banishment(string text, bool flg = false)
        {
            const string FAILED_MESSAGE = "失敗しました";
            if (client == null) { return FAILED_MESSAGE; }
            if (networkStream == null ) { return ""; }

            try
            {
                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck packet;
                if (flg)
                {
                    packet = new Pck(0x2f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("banplayer " + text));
                    networkStream.Write(packet.ToBytes(), 0, packet.Length);
                }
                else
                {
                    packet = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.ASCII.GetBytes("kickplayer " + text));
                    networkStream.Write(packet.ToBytes(), 0, packet.Length);
                }

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch (Exception)
            {
                return FAILED_MESSAGE;
            }
        }

        public static async Task<string> CustomCommand(string text)
        {
            const string FAILED_MESSAGE = "失敗しました";
            if (client == null) { return FAILED_MESSAGE; }

            try
            {
                if (networkStream == null) { return ""; }

                while (networkStream.DataAvailable) { _ = networkStream.ReadByte(); }
                Pck packet = new Pck(0x1f, PacketType.EXECCOMMAND, Encoding.UTF8.GetBytes(text));
                networkStream.Write(packet.ToBytes(), 0, packet.Length);

                int size = networkStream.ReadByte();
                byte[] data = new byte[size];

                await networkStream.ReadAsync(data, 0, size);

                string responseMessage = Encoding.UTF8.GetString(data.Skip(PACKET_HEADER).ToArray());
                return responseMessage;
            }
            catch (Exception)
            {
                return FAILED_MESSAGE;
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