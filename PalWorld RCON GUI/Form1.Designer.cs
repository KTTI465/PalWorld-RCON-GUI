namespace PalWorldR
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectionS = new System.Windows.Forms.Button();
            this.IPAddress = new System.Windows.Forms.TextBox();
            this.PortNum = new System.Windows.Forms.TextBox();
            this.AdPass = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.PlayerBox = new System.Windows.Forms.TextBox();
            this.ConnectionE = new System.Windows.Forms.Button();
            this.ShutDowmM = new System.Windows.Forms.TextBox();
            this.ShutDownSec = new System.Windows.Forms.TextBox();
            this.BroadCastM = new System.Windows.Forms.TextBox();
            this.GetPlayerSec = new System.Windows.Forms.TextBox();
            this.GetPlayerButton = new System.Windows.Forms.Button();
            this.BroadCastButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ShutDownButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.DoExitButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.KickButton = new System.Windows.Forms.Button();
            this.KBID = new System.Windows.Forms.TextBox();
            this.BanButton = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cli = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConnectionS
            // 
            this.ConnectionS.Location = new System.Drawing.Point(27, 160);
            this.ConnectionS.Name = "ConnectionS";
            this.ConnectionS.Size = new System.Drawing.Size(321, 23);
            this.ConnectionS.TabIndex = 0;
            this.ConnectionS.Text = "接続";
            this.ConnectionS.UseVisualStyleBackColor = true;
            this.ConnectionS.Click += new System.EventHandler(this.StartConnect);
            // 
            // IPAddress
            // 
            this.IPAddress.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IPAddress.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.IPAddress.Location = new System.Drawing.Point(203, 75);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(144, 22);
            this.IPAddress.TabIndex = 3;
            this.IPAddress.Text = "127.0.0.1";
            // 
            // PortNum
            // 
            this.PortNum.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortNum.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PortNum.Location = new System.Drawing.Point(203, 103);
            this.PortNum.Name = "PortNum";
            this.PortNum.Size = new System.Drawing.Size(89, 22);
            this.PortNum.TabIndex = 4;
            this.PortNum.Text = "25575";
            // 
            // AdPass
            // 
            this.AdPass.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AdPass.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.AdPass.Location = new System.Drawing.Point(203, 131);
            this.AdPass.Name = "AdPass";
            this.AdPass.PasswordChar = '*';
            this.AdPass.Size = new System.Drawing.Size(144, 22);
            this.AdPass.TabIndex = 7;
            // 
            // LogBox
            // 
            this.LogBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LogBox.Location = new System.Drawing.Point(382, 79);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(307, 245);
            this.LogBox.TabIndex = 8;
            // 
            // PlayerBox
            // 
            this.PlayerBox.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PlayerBox.Location = new System.Drawing.Point(382, 350);
            this.PlayerBox.Multiline = true;
            this.PlayerBox.Name = "PlayerBox";
            this.PlayerBox.ReadOnly = true;
            this.PlayerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PlayerBox.Size = new System.Drawing.Size(307, 225);
            this.PlayerBox.TabIndex = 11;
            // 
            // ConnectionE
            // 
            this.ConnectionE.Location = new System.Drawing.Point(27, 189);
            this.ConnectionE.Name = "ConnectionE";
            this.ConnectionE.Size = new System.Drawing.Size(321, 23);
            this.ConnectionE.TabIndex = 14;
            this.ConnectionE.Text = "切断";
            this.ConnectionE.UseVisualStyleBackColor = true;
            this.ConnectionE.Click += new System.EventHandler(this.StopConnect);
            // 
            // ShutDowmM
            // 
            this.ShutDowmM.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShutDowmM.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ShutDowmM.Location = new System.Drawing.Point(125, 266);
            this.ShutDowmM.Name = "ShutDowmM";
            this.ShutDowmM.Size = new System.Drawing.Size(223, 22);
            this.ShutDowmM.TabIndex = 15;
            this.ShutDowmM.Text = "Reboot_after_5_minutes";
            // 
            // ShutDownSec
            // 
            this.ShutDownSec.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShutDownSec.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.ShutDownSec.Location = new System.Drawing.Point(28, 266);
            this.ShutDownSec.Name = "ShutDownSec";
            this.ShutDownSec.Size = new System.Drawing.Size(48, 22);
            this.ShutDownSec.TabIndex = 17;
            this.ShutDownSec.Text = "300";
            // 
            // BroadCastM
            // 
            this.BroadCastM.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BroadCastM.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BroadCastM.Location = new System.Drawing.Point(28, 344);
            this.BroadCastM.Name = "BroadCastM";
            this.BroadCastM.Size = new System.Drawing.Size(320, 22);
            this.BroadCastM.TabIndex = 19;
            this.BroadCastM.Text = "Welcome!!!";
            // 
            // GetPlayerSec
            // 
            this.GetPlayerSec.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GetPlayerSec.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GetPlayerSec.Location = new System.Drawing.Point(28, 424);
            this.GetPlayerSec.Name = "GetPlayerSec";
            this.GetPlayerSec.Size = new System.Drawing.Size(49, 22);
            this.GetPlayerSec.TabIndex = 23;
            this.GetPlayerSec.Text = "2";
            this.GetPlayerSec.TextChanged += new System.EventHandler(this.GetPSec_TextChanged);
            // 
            // GetPlayerButton
            // 
            this.GetPlayerButton.Location = new System.Drawing.Point(118, 423);
            this.GetPlayerButton.Name = "GetPlayerButton";
            this.GetPlayerButton.Size = new System.Drawing.Size(230, 23);
            this.GetPlayerButton.TabIndex = 25;
            this.GetPlayerButton.Text = "取得開始";
            this.GetPlayerButton.UseVisualStyleBackColor = true;
            this.GetPlayerButton.Click += new System.EventHandler(this.CollectPlayer);
            // 
            // BroadCastButton
            // 
            this.BroadCastButton.Location = new System.Drawing.Point(27, 372);
            this.BroadCastButton.Name = "BroadCastButton";
            this.BroadCastButton.Size = new System.Drawing.Size(321, 23);
            this.BroadCastButton.TabIndex = 26;
            this.BroadCastButton.Text = "送信";
            this.BroadCastButton.UseVisualStyleBackColor = true;
            this.BroadCastButton.Click += new System.EventHandler(this.SendMessage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(25, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "サーバーアドレス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(25, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Adminパスワード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(25, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "サーバーポート";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(134, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "全般設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(379, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "ログ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(379, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "プレイヤー情報";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(111, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "コントロールパネル";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(25, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 15);
            this.label8.TabIndex = 34;
            this.label8.Text = "シャットダウン";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(25, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "プレイヤー情報取得";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(175, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(370, 27);
            this.label11.TabIndex = 37;
            this.label11.Text = "PalWorld RCON GUI（開発中）";
            // 
            // ShutDownButton
            // 
            this.ShutDownButton.Location = new System.Drawing.Point(27, 294);
            this.ShutDownButton.Name = "ShutDownButton";
            this.ShutDownButton.Size = new System.Drawing.Size(321, 23);
            this.ShutDownButton.TabIndex = 38;
            this.ShutDownButton.Text = "送信";
            this.ShutDownButton.UseVisualStyleBackColor = true;
            this.ShutDownButton.Click += new System.EventHandler(this.ShutdownAsync);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(486, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "更新日時：";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(25, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "全体メッセージ(ブロードキャスト)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(25, 581);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 15);
            this.label13.TabIndex = 40;
            this.label13.Text = "※入力は半角英数のみ対応です";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(75, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 15);
            this.label14.TabIndex = 41;
            this.label14.Text = "秒後";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.Location = new System.Drawing.Point(75, 427);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 42;
            this.label15.Text = "毎秒";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(24, 456);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(180, 15);
            this.label16.TabIndex = 44;
            this.label16.Text = "強制シャットダウン(DoExit)";
            // 
            // DoExitButton
            // 
            this.DoExitButton.Location = new System.Drawing.Point(27, 474);
            this.DoExitButton.Name = "DoExitButton";
            this.DoExitButton.Size = new System.Drawing.Size(321, 23);
            this.DoExitButton.TabIndex = 43;
            this.DoExitButton.Text = "送信";
            this.DoExitButton.UseVisualStyleBackColor = true;
            this.DoExitButton.Click += new System.EventHandler(this.DoExit);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.Location = new System.Drawing.Point(25, 506);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 15);
            this.label17.TabIndex = 47;
            this.label17.Text = "追放(PID, SteamID)";
            // 
            // KickButton
            // 
            this.KickButton.Location = new System.Drawing.Point(27, 552);
            this.KickButton.Name = "KickButton";
            this.KickButton.Size = new System.Drawing.Size(140, 23);
            this.KickButton.TabIndex = 46;
            this.KickButton.Text = "Kick";
            this.KickButton.UseVisualStyleBackColor = true;
            this.KickButton.Click += new System.EventHandler(this.Kick);
            // 
            // KBID
            // 
            this.KBID.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KBID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KBID.Location = new System.Drawing.Point(28, 524);
            this.KBID.Name = "KBID";
            this.KBID.Size = new System.Drawing.Size(320, 22);
            this.KBID.TabIndex = 45;
            // 
            // BanButton
            // 
            this.BanButton.Location = new System.Drawing.Point(204, 552);
            this.BanButton.Name = "BanButton";
            this.BanButton.Size = new System.Drawing.Size(144, 23);
            this.BanButton.TabIndex = 48;
            this.BanButton.Text = "BAN";
            this.BanButton.UseVisualStyleBackColor = true;
            this.BanButton.Click += new System.EventHandler(this.Ban);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(25, 611);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 15);
            this.label18.TabIndex = 50;
            this.label18.Text = "CLI(デバッグ用)";
            // 
            // cli
            // 
            this.cli.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cli.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cli.Location = new System.Drawing.Point(28, 629);
            this.cli.Name = "cli";
            this.cli.Size = new System.Drawing.Size(661, 22);
            this.cli.TabIndex = 49;
            this.cli.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 664);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cli);
            this.Controls.Add(this.BanButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.KickButton);
            this.Controls.Add(this.KBID);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.DoExitButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ShutDownButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BroadCastButton);
            this.Controls.Add(this.GetPlayerButton);
            this.Controls.Add(this.GetPlayerSec);
            this.Controls.Add(this.BroadCastM);
            this.Controls.Add(this.ShutDownSec);
            this.Controls.Add(this.ShutDowmM);
            this.Controls.Add(this.ConnectionE);
            this.Controls.Add(this.PlayerBox);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.AdPass);
            this.Controls.Add(this.PortNum);
            this.Controls.Add(this.IPAddress);
            this.Controls.Add(this.ConnectionS);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "PalWorld RCON GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectionS;
        private System.Windows.Forms.TextBox IPAddress;
        private System.Windows.Forms.TextBox PortNum;
        private System.Windows.Forms.TextBox AdPass;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.TextBox PlayerBox;
        private System.Windows.Forms.Button ConnectionE;
        private System.Windows.Forms.TextBox ShutDowmM;
        private System.Windows.Forms.TextBox ShutDownSec;
        private System.Windows.Forms.TextBox BroadCastM;
        private System.Windows.Forms.TextBox GetPlayerSec;
        private System.Windows.Forms.Button GetPlayerButton;
        private System.Windows.Forms.Button BroadCastButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ShutDownButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button DoExitButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button KickButton;
        private System.Windows.Forms.TextBox KBID;
        private System.Windows.Forms.Button BanButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox cli;
    }
}

