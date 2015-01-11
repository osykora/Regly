using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsAny : ContainsBase, IContainsAny
    {
        public ContainsAny(string sourceString, Stack<Expression> expressionCallStack)
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