using System.Collections.Generic;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsDigit : ContainsBase, IContainsDigit
    {
        public ContainsDigit(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IContainsDigit AtTheBeggining()
        {
            ExpressionCallStack.Push(Expression.AtTheBeggining);

            return new ContainsDigit(SourceString, ExpressionCallStack);
        }

        public IContainsQuantity AtTheBegginingOf()
        {
            ExpressionCallStack.Push(Expression.AtTheBegginingOf);

            return new ContainsQuantity(SourceString, ExpressionCallStack);
        }

        public IContainsQuantity AnywhereIn()
        {
            ExpressionCallStack.Push(Expression.AnywhereIn);

            return new ContainsQuantity(SourceString, ExpressionCallStack);
        }
    }
}