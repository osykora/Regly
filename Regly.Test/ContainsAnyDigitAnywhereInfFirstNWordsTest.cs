using Xunit.Extensions;
using Shouldly;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInfFirstNWordsTest
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("1F", 1)]
        [InlineData("F1", 1)]
        [InlineData("1 second", 1)]
        [InlineData("1F second", 1)]
        [InlineData("F1 second", 1)]
        [InlineData("1 se2cond", 1)]
        [InlineData("1 se2cond", 2)]
        [InlineData("1 second2", 2)]
        [InlineData("1 se2cond2", 2)]
        [InlineData("Fi1rst Se2cond", 2)]
        [InlineData("Fi1rst Se2cond Third", 2)]
        [InlineData("Fi1rst Se2cond Th3ird", 2)]
        [InlineData("Fi1rst Se2cond Th3ird", 3)]
        [InlineData("Fi1rst Se2cond Th3ird Fourth", 3)]
        public void ItShouldBeTrue(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AnywhereIn().First(count).Words();

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("F", 1)]
        [InlineData("F 2", 1)]
        [InlineData("F1 Second", 2)]
        [InlineData("F S2econd", 2)]
        [InlineData("Fi1rst Second Th3ird", 2)]
        [InlineData("First Se2cond Th3ird", 2)]
        [InlineData("Fi1rst Se2cond Third", 3)]
        [InlineData("1First 2Second Third 4Fourth", 3)]
        public void ItShouldBeFalse(string inputString, int count)
        {
            var regly = new Regly(inputString).Contains().AnyDigit().AnywhereIn().First(count).Words();

            regly.Execute().ShouldBe(false);
        }
    }
}
