using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Shouldly;

namespace Regly.Test
{
    public class SplitTest
    {
        [Fact]
        public void GivenAbc_WhenSplitByNull_ThenArgumentNullExceptionShouldBeThrown()
        {
            Should.Throw<ArgumentNullException>(() => new Regly("abc").SplitBy(null));
        }

        [Fact]
        public void GivenAbc_WhenSplitByEmptyString_ThenItShouldBeAbc()
        {
            new Regly("abc").SplitBy(string.Empty).Execute().ShouldBe(new[] { "abc" });
        }

        [Fact]
        public void GivenAbc_WhenSplitByWhiteSpace_ThenItShouldBeAbc()
        {
            new Regly("abc").SplitBy(string.Empty).Execute().ShouldBe(new[] { "abc" });
        }
    }
}
