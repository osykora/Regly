using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Shouldly;

namespace Regly.Test
{
    public class ContainsTest
    {
        [Fact]
        public void GivenOneWord_WhenSearchForNull_ThenArgumentNullExceptionShouldBeThrown()
        {
            Should.Throw<ArgumentNullException>(() => new Regly("Word").Contains(null));
        }

        [Fact]
        public void GivenOneWord_WhenSearchTheSameWord_ThenTheWordShouldBeFound()
        {
            new Regly("Word").Contains("Word").Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenOneWord_WhenSearchForDifferentWord_ThenTheWordShouldNotBeFound()
        {
            new Regly("Word").Contains("Different").Execute().ShouldBe(false);
        }

        [Fact]
        public void GivenTwoWords_WhenSearchForFirstOfThem_ThenTheWordShouldBeFound()
        {
            new Regly("Two words").Contains("Two").Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWords_WhenSearchForTheSecondOne_ThenTheWordShouldBeFound()
        {
            new Regly("Two words").Contains("words").Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWordsPhrase_WhenSearchForTheWholePhrase_ThenItShouldBeFound()
        {
            new Regly("Two words").Contains("Two words").Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenTwoWordsPhrase_WhenSearchForTheWholeReversePhrase_ThenItShouldNotBeFound()
        {
            new Regly("words two").Contains("Two words").Execute().ShouldBe(false);
        }

        [Fact]
        public void GivenUpperCaseWord_WhenSearchForItCaseInsensitive_ThenTheWordShouldBeFound()
        {
            new Regly("UPPER").Contains("upper").CaseInsensitive().Execute().ShouldBe(true);
        }

        [Fact]
        public void GivenUpperCaseWord_WhenSearchForItCaseSensitive_ThenTheWordShouldNotBeFound()
        {
            new Regly("UPPER").Contains("upper").CaseSensitive().Execute().ShouldBe(false);
        }

        [Fact]
        public void GivenUpperCaseWordAndNotSpecifiedSearchType_WhenSearchForItCaseSensitive_ThenItSearchCaseSensitiveAndTheWordShouldNotBeFound()
        {
            new Regly("UPPER").Contains("upper").Execute().ShouldBe(false);
        }
    }
}
