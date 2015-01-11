using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsEvery : ContainsBase, IContainsEvery
    {
        public ContainsEvery(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IExecutableExpression Word()
        {
            ExpressionCallStack.Push(Expression.Word);

            return this;
        }
    }
}