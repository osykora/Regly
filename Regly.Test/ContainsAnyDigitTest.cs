using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Shouldly;
using Regly.Interfaces;

namespace Regly.Test
{
    public class ContainsAnyDigitTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit();
        }

        protected override string GetExpectedExpressionForTest()
        {
            return @"\d";
        }

        [Fact]
        public void GivenOne_ThenItShouldBeTrue()
        {
            ShouldBeTrue("1");
        }

        [Fact]
        public void GivenWordWithDigitAtTheBeggining_ThenItShouldBeTrue()
        {
            ShouldBeTrue("1a");
        }

        [Fact]
        public void GivenWordWithDigitAtSecondPosition_ThenItShouldBeTrue()
        {
            ShouldBeTrue("a1");
        }

        [Fact]
        public void GivenTwoWordsWithDigitInTheFirstOne_ThenItShouldBeTrue()
        {
            ShouldBeTrue("First1 Second");
        }

        [Fact]
        public void GivenTwoWordsWithDigitInTheSecondOne_ThenItShouldBeTrue()
        {
            ShouldBeTrue("First Second2");
        }

        [Fact]
        public void GivenWordWithNoDigit_ThenItShouldBeFalse()
        {
            ShouldBeFalse("Word");
        }

        [Fact]
        public void GivenTwoWordsWithNoGigit_ThenItShouldBeFalse()
        {
            ShouldBeFalse("No digit");
        }
    }
}
