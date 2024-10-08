namespace UserSettings.Console
{
    public interface ISettingsData
    {
        void SaveSettings(string settings);
        string GetSettings();
    }
}
