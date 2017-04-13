using Meteobridge.Helpers;
using Should;
using Xunit;

namespace Meteobridge.Tests
{
    public class DataHelperTests
    {
        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData("notaboolean", false)]
        public void GetBoolValue(object input, bool expectedValue)
        {
            //Act
            var outputValue = DataHelper.GetBoolValue(input);

            //Assert
            outputValue.ShouldEqual(expectedValue);
        }

        [Theory]
        [InlineData("12.3", ".", 12.3)]
        [InlineData("12,3", ",", 12.3)]
        [InlineData("12,3", ".", 123)]
        [InlineData("12.3", ",", 0)]
        [InlineData("notadouble", ",", 0)]
        public void GetDoubleValue(object input, string seperator, double expectedValue)
        {
            //Act
            var outputValue = DataHelper.GetDoubleValue(input, seperator);

            //Assert
            outputValue.ShouldEqual(expectedValue);
        }
    }
}
