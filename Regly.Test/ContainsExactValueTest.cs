using System;
using Xunit;
using Shouldly;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsExactValueTest
    {
        [Fact]
        public void GivenOneWord_WhenSearchForNull_ThenArgumentNullExceptionShouldBeThrown()
        {
            Should.Throw<ArgumentNullException>(() => new Regly("Word").Contains(null));
        }

        [Fact]
        public void GivenUpperCaseWord_WhenSearchForItCaseInsensitive_ThenTheWordShouldBeFound()
        {
            var regly = new Regly("UPPER").Contains("upper").CaseInsensitive();

            regly.Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenUpperCaseWord_WhenSearchForItCaseSensitive_ThenTheWordShouldNotBeFound()
        {
            var regly = new Regly("UPPER").Contains("upper").CaseSensitive();

            regly.Execute().ShouldBe(false);
        }

        [Theory]
        [InlineData("Word", "Word")]
        [InlineData("Two words", "Two")]
        [InlineData("Two words", "words")]
        [InlineData("Two words", "Two words")]
        public void ItShouldBeTrue(string inputString, string contains)
        {
            var regly = new Regly(inputString).Contains(contains);

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("Word", "Different")]
        [InlineData("words two", "Two words")]
        [InlineData("UPPER", "upper")]
        public void ItShouldBeFalse(string inputString, string contains)
        {
            var regly = new Regly(inputString).Contains(contains);

            regly.Execute().ShouldBe(false);
        }
    }
}
