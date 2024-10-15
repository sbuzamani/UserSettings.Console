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
            int output;
            var result = _settingsService.ValidateInputGetOutput(input, out output);
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_InputIsOutOfRangeString_ReturnsFalse()
        {
            var input = "16";
            int output;
            var result = _settingsService.ValidateInputGetOutput(input, out output);
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_InputIsEmptyString_ReturnsFalse()
        {
            var input = "";
            int output;
            var result = _settingsService.ValidateInputGetOutput(input, out output);
            Assert.False(result);
        }

        [Fact]
        public void ValidateInput_InputIsInRangeString_ReturnsTrueAndValidInt()
        {
            var input = "7";
            int output;
            var result = _settingsService.ValidateInputGetOutput(input, out output);
            Assert.True(result);
            Assert.IsType<int>(output);
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