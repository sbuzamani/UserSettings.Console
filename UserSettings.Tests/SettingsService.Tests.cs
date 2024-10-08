using Moq;
using UserSettings.Console;

namespace UserSettings.Tests
{
    public class SettingServiceTests
    {
        private Mock<ISettingsData> _settingsServiceMoq;
        private SettingsService _settingsService;
        public SettingServiceTests()
        {
           _settingsServiceMoq = new Mock<ISettingsData>();
           _settingsService = new SettingsService();
        }

        [Fact]
        public void ValidateInput_WhenInputIsString_ReturnsFalse()
        {
            var input = "this is a string";
            var result = _settingsService.ValidateInput(input);
            Assert.False(result.Item1);
        }

        [Fact]
        public void ValidateInput_InputIsOutOfRangeString_ReturnsFalse()
        {
            var input = "16";
            var result = _settingsService.ValidateInput(input);
            Assert.False(result.Item1);
        }

        [Fact]
        public void ValidateInput_InputIsEmptyString_ReturnsFalse()
        {
            var input = "";
            var result = _settingsService.ValidateInput(input);
            Assert.False(result.Item1);
        }

        [Fact]
        public void ValidateInput_InputIsInRangeString_ReturnsTrueAndValidInt()
        {
            var input = "7";
            var result = _settingsService.ValidateInput(input);
            Assert.True(result.Item1);
            Assert.IsType<int>(result.Item2);
        }

        [Fact]
        public void IsSettingEnabled_IsDisabled_ReturnsFalse()
        {
            var input = 5;
            var result = _settingsService.IsSettingEnabled(input); 
            Assert.False(result);
        }

        [Fact]
        public void IsSettingEnabled_IsEnabled_ReturnsFalse()
        {
            var input = 7;
            var result = _settingsService.IsSettingEnabled(input);
            Assert.True(result);
        }
    }
}