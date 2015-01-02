using System.Collections.Generic;
using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingOfAnyWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AtTheBegginingOf().Any().Word();
        }

        protected override IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "12";
            yield return "1a";
            yield return "1First 2Second";
            yield return "1First Second";
            yield return "First 2Second";
        }

        protected override IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "a1";
            yield return "First1 Second";
            yield return "First Second2";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof (ContainsAnyDigitAtTheBegginingOfAnyWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}