using System.Collections.Generic;
using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAnywhereInAnyWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AnywhereIn().Any().Word();
        }

        protected override IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "1a";
            yield return "a1";
            yield return "1First 2Second";
            yield return "First1 Second";
            yield return "First S2econd";
            yield return "First Second2";
        }

        protected override IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAnywhereInAnyWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
