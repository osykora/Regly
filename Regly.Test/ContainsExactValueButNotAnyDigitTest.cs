using Shouldly;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsExactValueButNotAnyDigitTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("First", "First")]
        [InlineData("First Second", "Second")]
        [InlineData("First Second", "First Second")]
        [InlineData("First Second Third", "Second")]
        public void ItShouldBeTrue(string inputString, string contains)
        {
            var regly = new Regly(inputString).Contains(contains).ButNot().AnyDigit();

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("First", "")]
        [InlineData("First", "1")]
        [InlineData("First", "A")]
        [InlineData("First 2", "First")]
        [InlineData("First 2", "2")]
        [InlineData("1 Second", "Second")]
        [InlineData("1 Second", "1")]
        [InlineData("1", "1")]
        [InlineData("First Second 3", "First Second")]
        [InlineData("First 2 Third", "Third")]
        public void ItShouldBeFalse(string inputString, string contains)
        {
            var regly = new Regly(inputString).Contains(contains).ButNot().AnyDigit();

            regly.Execute().ShouldBe(false);
        }
    }
}
