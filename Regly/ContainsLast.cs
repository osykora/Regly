using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsLast : ContainsBase, IContainsLast
    {
        public ContainsLast(string sourceString, Stack<Expression> expressionCallStack)
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