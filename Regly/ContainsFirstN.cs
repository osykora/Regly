using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
