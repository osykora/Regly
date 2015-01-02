using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInFirstWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AnywhereIn().First().Word();
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "Fi1rst";
            yield return "1First Second";
            yield return "Fi1rst Second";
            yield return "First1 Second";
            yield return "Fi1rst 2Second";
            yield return "1First Second Third";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "First 2Second";
            yield return "First Se2cond";
            yield return "First Second2";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAnywhereInFirstWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
