namespace UserSettings.Console
{
    public interface ISettings
    {
        void SaveSettings(string settings);
        string GetSettings();
    }
}
