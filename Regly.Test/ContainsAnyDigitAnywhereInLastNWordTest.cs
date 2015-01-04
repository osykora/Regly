using Shouldly;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInLastNWordTest
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1F", 1)]
        [InlineData("First 2Second", 1)]
        [InlineData("First sec2ond", 1)]
        [InlineData("First second2", 1)]
        [InlineData("1First 2second", 1)]
        [InlineData("Fi1rst sec2ond", 2)]
        [InlineData("First 2Second 3Third", 2)]
        [InlineData("1First 2Second 3Third", 2)]
        [InlineData("1First 2Second 3Third", 3)]
        [InlineData("First 2Second 3Third 4Fourth", 3)]
        public void ItShouldBeTrue(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AnywhereIn().Last(count).Words();

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("First", 1)]
        [InlineData("First Second", 1)]
        [InlineData("Fi1rst Second", 1)]
        [InlineData("Fi1rst Second", 2)]
        [InlineData("First Se2cond", 2)]
        [InlineData("1First Second 3Third", 2)]
        [InlineData("1First 2Second Third", 2)]
        [InlineData("First 2Second 3Third", 3)]
        [InlineData("1First 2Second Third 4Fourth", 3)]
        public void ItShouldBeFalse(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AnywhereIn().Last(count).Words();

            regly.Execute().ShouldBe(false);
        }
    }
}
