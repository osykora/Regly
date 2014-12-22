using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Shouldly;
using Regly.Interfaces;

namespace Regly.Test
{
    public class ContainsAnyDigitAtTheBegginingTest : ContainsBaseTest
    {
        protected override IExecutableExpression CreateReglyForTest(IRegly regly)
        {
            return regly.Contains().AnyDigit().AtTheBeggining();
        }

        protected override string GetExpectedExpressionForTest()
        {
            return @"^\d";
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
        public void GivenWordWithDigitAtSecondPosition_ThenItShouldBeFalse()
        {
            ShouldBeFalse("a1");
        }

        [Fact]
        public void GivenTwoWordsWithDigitInTheFirstOneAtTheBegging_ThenItShouldBeTrue()
        {
            ShouldBeTrue("1First Second");
        }

        [Fact]
        public void GivenTwoWordsWithDigitInTheSecondOneAtTheBeggining_ThenItShouldBeFalse()
        {
            ShouldBeFalse("First 2Second");
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
