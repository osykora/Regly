using Regly.Interfaces;
using Shouldly;
using System.Collections.Generic;

namespace Regly.Test
{
    public abstract class ContainsBaseTest : IEnumerable<object[]>
    {
        protected abstract IExecutableExpression CreateReglyForTest(IRegly regly);

        protected abstract IEnumerable<string> GetInputStringsForTrueCase();

        protected abstract IEnumerable<string> GetInputStringsForFalseCase();

        protected void ShouldBe(string inputString, bool expectedResult)
        {
            var regly = CreateReglyForTest(new Regly(inputString));

            regly.Execute().ShouldBe(expectedResult);
        }

        private IEnumerable<object[]> ConvertDataToEnumerator()
        {
            foreach (string item in GetInputStringsForTrueCase())
            {
                yield return new object[] { item, true };
            }

            foreach (string item in GetInputStringsForFalseCase())
            {
                yield return new object[] { item, false };
            }
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return ConvertDataToEnumerator().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
