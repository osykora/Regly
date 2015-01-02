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
            expressionCallStack.Push(Expression.AtTheBeggining);

            return new ContainsDigit(sourceString, expressionCallStack);
        }

        public IContainsQuantity AtTheBegginingOf()
        {
            expressionCallStack.Push(Expression.AtTheBegginingOf);

            return new ContainsQuantity(sourceString, expressionCallStack);
        }

        public IContainsQuantity AnywhereIn()
        {
            expressionCallStack.Push(Expression.AnywhereIn);

            return new ContainsQuantity(sourceString, expressionCallStack);
        }
    }
}