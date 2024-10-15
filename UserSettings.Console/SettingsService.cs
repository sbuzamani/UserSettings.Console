namespace UserSettings.Console
{
    public class SettingsService : ISettingsService
    {

        private ISettingsData settingsData;
        const string settingsString = "00000010";

        public string GetSettings()
        {
            return settingsData.GetSettings();
        }

        public bool IsSettingEnabled(int settingId)
        {
            var settings = settingsString.ToCharArray();
            //Assuming that users insert 1 based numbers to check enabled settings instead of 0 based
            var settingState = settings[settingId - 1];

            if (settingState == '0')
            {
                return false;
            }

            return true;
        }

        public void SaveSettings(string settings)
        {
            settingsData.SaveSettings(settings);
        }

        public bool ValidateInputGetOutput(string input, out int output)
        {
            output = default;
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var isValid = int.TryParse(input, out int intSetting);
            if (!isValid)
            {
                return false;
            }

            if (!InBounds(intSetting))
            {
                return false;
            }

            output = intSetting;
            return true;
        }

        private bool InBounds(int settingId)
        {
            if (settingId == 0 || settingId > settingsString.Length)
            {
                return false;
            }

            return true;
        }
    }
}
