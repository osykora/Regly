using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            return new ContainsDigit(this.sourceString, expressionCallStack);
        }

        public IContainsQuantity AtTheBegginingOf()
        {
            expressionCallStack.Push(Expression.AtTheBegginingOf);

            return new ContainsQuantity(this.sourceString, expressionCallStack);
        }
    }
}
