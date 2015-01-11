using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Regly.Interfaces;

namespace Regly
{
    public class ContainsValue : ContainsBase, IContainsValue
    {
        private bool caseSensitive;

        public ContainsValue(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
            CaseSensitive();
        }

        public IContainsValue CaseInsensitive()
        {
            caseSensitive = false;

            return this;
        }

        public IContainsValue CaseSensitive()
        {
            caseSensitive = true;

            return this;
        }

        public IContainsValue ButNot(string value)
        {
            if (value == null) throw new ArgumentNullException("value");

            ExpressionCallStack.Push(new Expression(ExpressionType.ButNotValue, value));

            return this;
        }

        public IContains ButNot()
        {
            ExpressionCallStack.Push(Expression.ButNot);

            return new Contains(SourceString, ExpressionCallStack);
        }

        public IContainsValue AtTheBeggining()
        {
            ExpressionCallStack.Push(Expression.AtTheBeggining);

            return this;
        }

        protected override RegexOptions GetRegexOptions()
        {
            return !caseSensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
        }
    }
}