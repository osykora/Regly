using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regly.Interfaces;
using Shouldly;

namespace Regly.Test
{
    public abstract class ContainsBaseTest
    {
        protected abstract IExecutableExpression CreateReglyForTest(IRegly regly);

        protected abstract string GetExpectedExpressionForTest();

        protected void ShouldBeTrue(string inputString)
        {
            ShouldBe(inputString, true);
        }

        protected void ShouldBeFalse(string inputString)
        {
            ShouldBe(inputString, false);
        }

        private void ShouldBe(string inputString, bool expectedResult)
        {
            var regly = CreateReglyForTest(new Regly(inputString));

            regly.Execute().ShouldBe(expectedResult);
            regly.GetExpression().ShouldBe(GetExpectedExpressionForTest());
        }
    }
}
