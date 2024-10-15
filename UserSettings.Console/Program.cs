using Microsoft.Extensions.DependencyInjection;
using UserSettings.Console;

internal class Program
{
    static bool isValidInput;
    private static ISettingsService _settingService;
    static string enabledResult;
    private static void Main(string[] args)
    {
        var services = InjectDependencies();
        _settingService = services.GetRequiredService<ISettingsService>();

        #region Question 2.2
        //var userSettings = GetSettingsService();
        //Saving settings strings to file
        //userSettings.SaveSettings(settingsString);
        //Getting settings from file
        //var settings = userSettings.GetSettings();
        #endregion

        int output;
        #region Question 2.1
        while (!isValidInput) {
            Console.Clear();
            Console.WriteLine("Please enter setting you want to check: ");
            var setting = Console.ReadLine();
            var isValid = _settingService.ValidateInputGetOutput(setting, out output);

            if (isValid)
            {
                var settingId = output;
                var isEnabled = _settingService.IsSettingEnabled(settingId);
                if (!isEnabled)
                {
                    enabledResult = "Setting is disabled";
                }
                else {
                    enabledResult = "Setting is enabled";
                }
                
                Console.WriteLine(enabledResult);
                Console.ReadLine();
                break;
            }
        }
        #endregion
    }
    
    private static ServiceProvider InjectDependencies()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISettingsData, SettingsData>()
            .AddScoped<ISettingsService, SettingsService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}