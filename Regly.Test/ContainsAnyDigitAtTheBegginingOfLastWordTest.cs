using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingOfLastWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AtTheBegginingOf().Last().Word();
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "1First";
            yield return "First 2Second";
            yield return "First Second 3Third";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "a1";
            yield return "First S2econd";
            yield return "1First Second2";
            yield return "1First 2Second Third";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAtTheBegginingOfLastWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
