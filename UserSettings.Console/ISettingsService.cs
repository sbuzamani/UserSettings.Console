namespace UserSettings.Console
{
    public interface ISettingsService
    {
        bool IsSettingEnabled(int settingId);
        void SaveSettings(string settings);
        string GetSettings();
        bool ValidateInputGetOutput(string input, out int output);
    }
}
