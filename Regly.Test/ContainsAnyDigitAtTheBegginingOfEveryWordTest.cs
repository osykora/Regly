using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Regly.Interfaces;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingOfEveryWordTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AtTheBegginingOf().Every().Word();
        }

        protected override string GetExpectedExpressionForTest()
        {
            return @"\b\d";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForTrueCase()
        {
            yield return "1";
            yield return "12";
            yield return "1a";
            yield return "1First 2Second";
        }

        protected override System.Collections.Generic.IEnumerable<string> GetInputStringsForFalseCase()
        {
            yield return "a1";
            yield return "1First Second";
            yield return "First 2Second";
            yield return "1First Second2";
            yield return "Word";
            yield return "No digit";
        }

        [Theory, ClassData(typeof(ContainsAnyDigitAtTheBegginingOfEveryWordTest))]
        public void ItShouldBe(string inputString, bool expectedResult)
        {
            ShouldBe(inputString, expectedResult);
        }
    }
}
