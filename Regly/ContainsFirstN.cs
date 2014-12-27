using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsFirstN : ContainsBase, IContainsFirstN
    {
        public ContainsFirstN(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IExecutableExpression Words()
        {
            expressionCallStack.Push(Expression.Words);

            return this;
        }
    }
}