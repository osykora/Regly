using System;
using Shouldly;
using Xunit;
using System.Globalization;

namespace Regly.Test
{
    public class ReglyConstructorTest
    {
        [Fact]
        public void GivenNullInputString_WhenCreatingNewInstanceOfRegly_ThenArgumentNullExceptionShouldBeThrown()
        {
            Should.Throw<ArgumentNullException>(() => new Regly(null));
        }

        [Fact]
        public void GivenEmptyInputString_WhenCreatingNewInstanceOfRegly_ThenInstanceShouldBeCreated()
        {
            new Regly(string.Empty);
        }
    }
}
