using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class Contains : ContainsBase, IContains
    {
        public Contains(string sourceString)
            : base(sourceString, new Stack<Expression>())
        {
        }

        public Contains(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IContainsDigit AnyDigit()
        {
            ExpressionCallStack.Push(Expression.AnyDigit);

            return new ContainsDigit(SourceString, ExpressionCallStack);
        }
    }
}