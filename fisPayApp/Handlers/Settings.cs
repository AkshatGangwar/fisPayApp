using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace fisPayApp.Handlers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string LoginSettingsKey = "last_Login_settings_key";
        private const string RememberChk = "rememberchk_val";
        private static readonly string SettingsDefault = string.Empty;
        private static readonly bool RemChkVal = false;

        #endregion


        public static string LastUsedLoginID
        {
            get
            {
                return AppSettings.GetValueOrDefault(LoginSettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(LoginSettingsKey, value);
            }
        }
        public static bool SetRememberChk
        {
            get
            {
                return AppSettings.GetValueOrDefault(RememberChk, RemChkVal);
            }
            set
            {
                AppSettings.AddOrUpdateValue(RememberChk, value);
            }
        }

    }
}
