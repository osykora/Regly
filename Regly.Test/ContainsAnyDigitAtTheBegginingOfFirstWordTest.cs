using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingOfFirstWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AtTheBegginingOf().First().Word();
        }

        protected override string GetExpectedExpressionForTest()
        {
            return @"^\d";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "1First Second";
            yield return "1First Second Third";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "a1";
            yield return "First 2Second";
            yield return "First Second 3Third";
            yield return "First2 Second";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAtTheBegginingOfFirstWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
