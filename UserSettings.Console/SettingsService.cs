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

        public Tuple<bool,int> ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Tuple.Create(false, new int());
            }

            var isValid = int.TryParse(input, out int intSetting);
            if (!isValid)
            {
                return Tuple.Create(false, new int());
            }

            if (!InBounds(intSetting))
            {
                return Tuple.Create(false, new int());
            }

            return Tuple.Create(isValid, intSetting);
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
