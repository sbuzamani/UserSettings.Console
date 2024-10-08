namespace UserSettings.Console
{
    public interface ISettingsService
    {
        bool IsSettingEnabled(int settingId);
        void SaveSettings(string settings);
        string GetSettings();
        Tuple<bool, int> ValidateInput(string input);
    }
}
