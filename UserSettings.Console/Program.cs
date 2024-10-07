using Microsoft.Extensions.DependencyInjection;
using UserSettings.Console;

internal class Program
{
    const string settingsString = "00000010";
    private static void Main(string[] args)
    {
        #region Question 2.2
        var userSettings = GetSettingsService();
        //Saving settings strings to file
        userSettings.SaveSettings(settingsString);
        //Getting settings from file
        var settings = userSettings.GetSettings();
        #endregion

        #region Question 2.1
        Console.WriteLine("Please enter setting you want to check: ");
        var setting = Console.ReadLine();

        var parseResult = int.TryParse(setting, out int intSetting);
        if (intSetting > settingsString.Length || !parseResult)
        {
            Console.WriteLine("Error reading setting.");
            Console.ReadLine();
        }
        var result = IsSettingEnabled(intSetting);

        Console.WriteLine(result);
        Console.ReadLine();
        #region
    }
    private static bool IsSettingEnabled(int setting)
    {
        var settings = settingsString.ToCharArray();
        //Assuming that users insert 1 based numbers to check enabled settings instead of 0 based
        var settingState = settings[setting - 1];
        if (settingState == '0')
        {
            return false;
        }

        return true;
    }

    private static ISettings GetSettingsService()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISettings, Settings>()
            .BuildServiceProvider();

        var settingsService = serviceProvider.GetService<ISettings>();
        return settingsService;
    }
}