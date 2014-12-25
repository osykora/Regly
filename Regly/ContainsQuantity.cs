using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsQuantity : ContainsBase, IContainsQuantity
    {
        public ContainsQuantity(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IContainsEvery Every()
        {
            expressionCallStack.Push(Expression.Every);

            return new ContainsEvery(this.sourceString, expressionCallStack);
        }


        public IContainsAny Any()
        {
            expressionCallStack.Push(Expression.Any);

            return new ContainsAny(this.sourceString, expressionCallStack);
        }


        public IContainsFirst First()
        {
            expressionCallStack.Push(Expression.First);

            return new ContainsFirst(this.sourceString, expressionCallStack);
        }


        public IContainsFirstN First(int count)
        {
            expressionCallStack.Push(new Expression(ExpressionType.FirstN, count));

            return new ContainsFirstN(this.sourceString, expressionCallStack);
        }
    }
}
