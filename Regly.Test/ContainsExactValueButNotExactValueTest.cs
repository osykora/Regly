using System;
using Shouldly;
using Xunit;
using Xunit.Extensions;

namespace Regly.Test
{
    public class ContainsExactValueButNotExactValueTest
    {
        [Fact]
        public void GivenOneWord_WhenSearchForNull_ThenArgumentNullExceptionShouldBeThrown()
        {
            Should.Throw<ArgumentNullException>(() => new Regly("Word").Contains("Word").ButNot(null));
        }

        [Theory]
        [InlineData("First", "First", "")]
        [InlineData("First", "First", "A")]
        [InlineData("First Second", "Second", "A")]
        [InlineData("First Second", "First Second", "A")]
        [InlineData("First Second Third", "Second", "A")]
        public void ItShouldBeTrue(string inputString, string contains, string notContains)
        {
            var regly = new Regly(inputString).Contains(contains).ButNot(notContains);

            regly.Execute().ShouldBe(true);
        }

        [Theory]
        [InlineData("First", "", "")]
        [InlineData("First", "", "A")]
        [InlineData("First", "A", "A")]
        [InlineData("First", "First", "i")]
        [InlineData("First Second", "Second", " ")]
        [InlineData("First Second", "First Second", "S")]
        [InlineData("First Second Third", "Second", "S")]
        public void ItShouldBeFalse(string inputString, string contains, string notContains)
        {
            var regly = new Regly(inputString).Contains(contains).ButNot(notContains);

            regly.Execute().ShouldBe(false);
        }
    }
}
