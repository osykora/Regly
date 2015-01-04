using Xunit.Extensions;
using Shouldly;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingOfLastNWordsTest
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1F", 1)]
        [InlineData("1 2second", 1)]
        [InlineData("1First 2second", 1)]
        [InlineData("1 2second", 1)]
        [InlineData("1 2Second", 2)]
        [InlineData("1First 2Second", 2)]
        [InlineData("First 2Second 3Third", 2)]
        [InlineData("1First 2Second 3Third", 2)]
        [InlineData("1First 2Second 3Third", 3)]
        [InlineData("First 2Second 3Third 4Fourth", 3)]
        public void ItShouldBeTrue(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AtTheBegginingOf().Last(count).Words();

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("F1", 1)]
        [InlineData("1 S2econd", 1)]
        [InlineData("F1 S2econd", 2)]
        [InlineData("1F S2econd", 2)]
        [InlineData("1First Second 3Third", 2)]
        [InlineData("1First 2Second Third", 2)]
        [InlineData("1First 2Second Third3", 3)]
        [InlineData("1First 2Second Third 4Fourth", 3)]
        public void ItShouldBeFalse(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AtTheBegginingOf().Last(count).Words();

            regly.Execute().ShouldBe(false);
        }
    }
}
