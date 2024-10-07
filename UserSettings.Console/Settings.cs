using System.Text;

namespace UserSettings.Console
{
    public class Settings : ISettings
    {

        public const string filePath = "savedsettings.txt";

        public string GetSettings()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.ASCII))
                {
                    var settings = streamReader.ReadToEnd();
                    return settings;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveSettings(string settings)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.ASCII))
            {
                sw.Write(settings);
            }
        }
    }
}
