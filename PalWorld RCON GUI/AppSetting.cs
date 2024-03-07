
using PalWorld_RCON_GUI.Properties;

namespace PalWorld_RCON_GUI
{
    internal class AppSetting
    {
        /// <summary></summary>
        public string ServerAddress { get; private set; } = "127.0.0.1";
        /// <summary>RCONポート</summary>
        public string RconPort { get; private set; } = "25575";
        /// <summary>管理者パスワード</summary>
        public string AdminPassword { get; private set; }

        /// <summary>設定をロード</summary>
        public void Load()
        {
            ServerAddress = Settings.Default.ServerAddress;
            RconPort = Settings.Default.RconPort;
            AdminPassword = Settings.Default.AdminPassword;
        }

        /// <summary>設定を保存</summary>
        public void Save()
        {
            Settings.Default.ServerAddress = ServerAddress;
            Settings.Default.RconPort = RconPort;
            Settings.Default.AdminPassword = AdminPassword;
            Settings.Default.Save();
        }

        /// <summary>設定項目</summary>
        public enum SettingTypes
        {
            ServerAddress,
            RconPort, 
            AdminPassword
        }

        /// <summary>設定を更新</summary>
        /// <param name="type">設定項目</param>
        /// <param name="text">設定値</param>
        public void UpdateSetting(SettingTypes type, string text)
        {
            switch (type)
            {
                case SettingTypes.ServerAddress:
                    ServerAddress = text;
                    break;
                case SettingTypes.RconPort:
                    RconPort= text;
                    break;
                case SettingTypes.AdminPassword:
                    AdminPassword = text;
                    break;
                default:
                    break;
            }
        }
    }
}
