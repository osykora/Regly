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
            ExpressionCallStack.Push(Expression.Every);

            return new ContainsEvery(SourceString, ExpressionCallStack);
        }


        public IContainsAny Any()
        {
            ExpressionCallStack.Push(Expression.Any);

            return new ContainsAny(SourceString, ExpressionCallStack);
        }


        public IContainsFirst First()
        {
            ExpressionCallStack.Push(Expression.First);

            return new ContainsFirst(SourceString, ExpressionCallStack);
        }


        public IContainsFirstN First(int count)
        {
            ExpressionCallStack.Push(new Expression(ExpressionType.FirstN, count));

            return new ContainsFirstN(SourceString, ExpressionCallStack);
        }

        public IContainsLast Last()
        {
            ExpressionCallStack.Push(Expression.Last);

            return new ContainsLast(SourceString, ExpressionCallStack);
        }

        public IContainsLastN Last(int count)
        {
            ExpressionCallStack.Push(new Expression(ExpressionType.LastN, count));

            return new ContainsLastN(SourceString, ExpressionCallStack);
        }
    }
}