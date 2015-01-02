using System.Collections.Generic;
using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInEveryWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AnywhereIn().Every().Word();
        }

        protected override IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "1First";
            yield return "First1";
            yield return "Fir1st";
            yield return "1First 2Second";
            yield return "First1 Second2";
            yield return "F1irst S2econd";
        }

        protected override IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "Word";
            yield return "No digit";
            yield return "1First Second";
            yield return "First 2Second";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAnywhereInEveryWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
