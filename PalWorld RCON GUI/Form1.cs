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
            textBox8.Text += text + Environment.NewLine;
        }
        public void SetPlayers(string text)
        {
            textBox12.Text = text;
        }

        private async void StartConnect(object sender, EventArgs e)
        {
            var s = "";
            await Task.Run(() =>
            s = Rcon.Connect(textBox3.Text, textBox4.Text, textBox6.Text).Result.ToString()
            );

            textBox8.Text += s;
            textBox8.Text += Environment.NewLine;

            if (s[3] == '成')
            {
                cflg = true;
                timer2.Start();
            }
        }

        private void StopConnect(object sender, EventArgs e)
        {
            Rcon.ProcessExit(sender, e);
            textBox8.Text += "切断しました" + Environment.NewLine;
            cflg = false;
            timer2.Stop();

            if (flg)
            {
                button3.Text = "取得開始";
                timer1.Stop();
            }
        }

        private async void SendMessage(object sender, EventArgs e)
        {
            var s = "";
            var n = Regex.Replace(textBox20.Text, @"\s", "");
            Console.WriteLine(n);
            await Task.Run(() =>
                s = Rcon.Broadcast(n).Result.ToString()
            );
            textBox8.Text += s;
            textBox8.Text += Environment.NewLine;
        }

        private async void CollectPlayer(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox18.Text) * 1000;
            label12.Text = $"更新日時:{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
            if (cflg)
            {
                flg = !flg;
                if (flg)
                {
                    button3.Text = "取得停止";
                    timer1.Start();
                }
                else
                {
                    button3.Text = "取得開始";
                    timer1.Stop();
                }
            }
        }

        private async void ShutdownAsync(object sender, EventArgs e)
        {
            /*var s = "";
            await Task.Run(() =>
                s = Program.Shutdown(textBox16.Text, textBox14.Text).Result.ToString()
            );
            textBox8.Text += s;
            textBox8.Text += Environment.NewLine;*/
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
            if (textBox12.InvokeRequired)
            {
                textBox12.Invoke((MethodInvoker)delegate { UpdatePlayers(text); });
            }
            else
            {
                label12.Text = $"更新日時:{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
                textBox12.Text = text;
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse(textBox18.Text) * 1000;
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            await Rcon.Reload();
        }
    }
}
