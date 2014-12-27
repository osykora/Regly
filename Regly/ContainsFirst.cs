using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsFirst : ContainsBase, IContainsFirst
    {
        public ContainsFirst(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IExecutableExpression Word()
        {
            expressionCallStack.Push(Expression.Word);

            return this;
        }
    }
}