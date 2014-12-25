using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Shouldly;

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
        public void GivenOneWord_WhenSearchTheSameWord_ThenTheWordShouldBeFound()
        {
            var regly = new Regly("Word").Contains("Word");

            regly.Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenOneWord_WhenSearchForDifferentWord_ThenTheWordShouldNotBeFound()
        {
            var regly = new Regly("Word").Contains("Different");

            regly.Execute().ShouldBe(false);
        }

        [Fact]
        public void GivenTwoWords_WhenSearchForFirstOfThem_ThenTheWordShouldBeFound()
        {
            var regly = new Regly("Two words").Contains("Two");

            regly.Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWords_WhenSearchForTheSecondOne_ThenTheWordShouldBeFound()
        {
            var regly = new Regly("Two words").Contains("words");

            regly.Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWordsPhrase_WhenSearchForTheWholePhrase_ThenItShouldBeFound()
        {
            var regly = new Regly("Two words").Contains("Two words");

            regly.Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWordsPhrase_WhenSearchForTheWholeReversePhrase_ThenItShouldNotBeFound()
        {
            var regly = new Regly("words two").Contains("Two words");

            regly.Execute().ShouldBe(false);
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

        [Fact]
        public void GivenUpperCaseWordAndNotSpecifiedSearchType_WhenSearchForForIt_ThenItSearchCaseSensitiveAndTheWordShouldNotBeFound()
        {
            var regly = new Regly("UPPER").Contains("upper");

            regly.Execute().ShouldBe(false);
        }
    }
}
