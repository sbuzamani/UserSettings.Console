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

        #region Question 2.1
        while (!isValidInput) {
            Console.Clear();
            Console.WriteLine("Please enter setting you want to check: ");
            var setting = Console.ReadLine();
            var result = _settingService.ValidateInput(setting);
            var isValid = result.Item1;

            if (isValid)
            {
                var settingId = result.Item2;
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