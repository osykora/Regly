using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInLastWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AnywhereIn().Last().Word();
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "Fi1rst";
            yield return "First1";
            yield return "1First";
            yield return "First 2Second";
            yield return "First Se2cond";
            yield return "First Second2";
            yield return "First Second Th3ird";
            yield return "1First 2Second";
            yield return "Fi1rst Se2cond";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "Fi1rst Second";
            yield return "1First Second";
            yield return "First1 Second";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAnywhereInLastWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
