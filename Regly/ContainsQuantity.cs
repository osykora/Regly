using System.Collections.Generic;
using Regly.Interfaces;

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

            return new ContainsEvery(sourceString, expressionCallStack);
        }


        public IContainsAny Any()
        {
            expressionCallStack.Push(Expression.Any);

            return new ContainsAny(sourceString, expressionCallStack);
        }


        public IContainsFirst First()
        {
            expressionCallStack.Push(Expression.First);

            return new ContainsFirst(sourceString, expressionCallStack);
        }


        public IContainsFirstN First(int count)
        {
            expressionCallStack.Push(new Expression(ExpressionType.FirstN, count));

            return new ContainsFirstN(sourceString, expressionCallStack);
        }

        public IContainsLast Last()
        {
            expressionCallStack.Push(Expression.Last);

            return new ContainsLast(sourceString, expressionCallStack);
        }

        public IContainsLastN Last(int count)
        {
            expressionCallStack.Push(new Expression(ExpressionType.LastN, count));

            return new ContainsLastN(sourceString, expressionCallStack);
        }
    }
}