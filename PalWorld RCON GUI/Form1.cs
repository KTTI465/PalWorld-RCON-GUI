using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PalWorldR
{
    public partial class Form1 : Form
    {
        bool flg = false;
        bool cflg = false;

        public Form1()
        {
            InitializeComponent();

            timer1 = new Timer();
            timer1.Tick += timer1_Tick;

            timer2 = new Timer();
            timer2.Tick += timer2_Tick;
            timer2.Interval = 25 * 1000;
        }

        public void SetLog(string text)
        {
            LogBox.Text += text + Environment.NewLine;
        }
        public void SetPlayers(string text)
        {
            PlayerBox.Text = text;
        }

        private async void StartConnect(object sender, EventArgs e)
        {
            var s = "";
            await Task.Run(() =>
            s = Rcon.Connect(IPAddress.Text, PortNum.Text, AdPass.Text).Result.ToString()
            );

            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;

            if (s[3] == '成')
            {
                cflg = true;
                timer2.Start();
            }
        }

        private void StopConnect(object sender, EventArgs e)
        {
            Rcon.ProcessExit(sender, e);
            LogBox.Text += "切断しました" + Environment.NewLine;
            cflg = false;
            timer2.Stop();

            if (flg)
            {
                GetPlayerButton.Text = "取得開始";
                timer1.Stop();
            }
        }

        private async void SendMessage(object sender, EventArgs e)
        {
            var s = "";
            var n = Regex.Replace(BroadCastM.Text, @"\s", "");
            Console.WriteLine(n);
            await Task.Run(() =>
                s = Rcon.Broadcast(n).Result.ToString()
            );
            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;
        }

        private async void CollectPlayer(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(GetPlayerSec.Text) * 1000;
            label12.Text = $"更新日時:{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
            if (cflg)
            {
                flg = !flg;
                if (flg)
                {
                    GetPlayerButton.Text = "取得停止";
                    timer1.Start();
                }
                else
                {
                    GetPlayerButton.Text = "取得開始";
                    timer1.Stop();
                }
            }
        }

        private async void ShutdownAsync(object sender, EventArgs e)
        {
            var s = "";
            var n = Regex.Replace(BroadCastM.Text, @"\s", "");

            DialogResult result = MessageBox.Show($"サーバーを{ShutDownSec.Text}秒後にシャットダウンしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;

            await Task.Run(() =>
                s = Rcon.ShutDown(ShutDownSec.Text, ShutDowmM.Text).Result.ToString()
            );
            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                string players = Rcon.GetPlayers().Result.ToString();
                UpdatePlayers(players);
            });
        }

        /// <summary>スレッドセーフにテキストを追加</summary>
        /// <remarks>同時に日時も更新</remarks>
        /// <param name="text">追加するテキスト</param>
        private void UpdatePlayers(string text)
        {
            if (PlayerBox.InvokeRequired)
            {
                PlayerBox.Invoke((MethodInvoker)delegate { UpdatePlayers(text); });
            }
            else
            {
                label12.Text = $"更新日時:{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
                PlayerBox.Text = text;
            }
        }

        private async void DoExit(object sender, EventArgs e)
        {
            var s = "";

            DialogResult result = MessageBox.Show($"サーバーを強制停止しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;

            Console.WriteLine("終了");
            await Task.Run(() =>
                s = Rcon.ShutDown(ShutDownSec.Text, ShutDowmM.Text, true).Result.ToString()
            );
            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;
        }

        private async void Kick(object sender, EventArgs e)
        {
            var s = "";

            DialogResult result = MessageBox.Show($"ID:{KBID.Text}を本当にキックしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;

            Console.WriteLine("終了");
            await Task.Run(() =>
                s = Rcon.Banishment(KBID.Text).Result.ToString()
            );
            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;
        }

        private async void Ban(object sender, EventArgs e)
        {
            var s = "";

            DialogResult result = MessageBox.Show($"ID:{KBID.Text}を本当にBANしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) return;

            Console.WriteLine("終了");
            await Task.Run(() =>
                s = Rcon.Banishment(KBID.Text, true).Result.ToString()
            );
            LogBox.Text += s;
            LogBox.Text += Environment.NewLine;
        }

        private void GetPSec_TextChanged(object sender, EventArgs e)
        {
            if (GetPlayerSec.Text != "")
            {
                try
                {
                    if (int.Parse(GetPlayerSec.Text) < 1) GetPlayerSec.Text = "1";
                    timer1.Interval = int.Parse(GetPlayerSec.Text) * 1000;
                }
                catch
                {
                    GetPlayerSec.Text = "1";
                    timer1.Interval = 1000;
                }
            }
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            await Rcon.Reload();
        }

        private async void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var s = "";
                await Task.Run(() =>
                    s = Rcon.CustomCommand(cli.Text).Result.ToString()
                );
                LogBox.Text += s;
                LogBox.Text += Environment.NewLine;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
