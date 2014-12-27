using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class Contains : IContains
    {
        private readonly string sourceString;

        public Contains(string sourceString)
        {
            this.sourceString = sourceString;
        }

        public IContainsDigit AnyDigit()
        {
            return new ContainsDigit(sourceString, new Stack<Expression>(new[] {Expression.AnyDigit}));
        }
    }
}