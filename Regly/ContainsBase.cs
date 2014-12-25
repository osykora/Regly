using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public abstract class ContainsBase
    {
        protected string sourceString;
        protected Stack<Expression> expressionCallStack;

        protected virtual RegexOptions GetRegexOptions()
        {
            return RegexOptions.None;
        }

        protected ContainsBase(string sourceString, Stack<Expression> expressionCallStack)
        {
            this.sourceString = sourceString;
            this.expressionCallStack = expressionCallStack;
        }

        private bool IsStackLike(params ExpressionType[] expressionTypes)
        {
            var queue = expressionCallStack.Reverse().Select(expression => expression.Type).ToArray();

            return queue.SequenceEqual(expressionTypes);
        }

        public bool Execute()
        {
            if (IsStackLike(ExpressionType.ExactValue))
            {
                Expression expression = expressionCallStack.Pop();
                var regex = new Regex(expression.Value, this.GetRegexOptions());

                return regex.IsMatch(this.sourceString);
            }
            else if (IsStackLike(ExpressionType.AnyDigit))
            {
                var regex = new Regex(@"\d", this.GetRegexOptions());

                return regex.IsMatch(this.sourceString);
            }
            else if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBeggining) ||
                IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.First, ExpressionType.Word))
            {
                var regex = new Regex(@"^\d", this.GetRegexOptions());

                return regex.IsMatch(this.sourceString);
            }
            else if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Every, ExpressionType.Word))
            {
                var regex = new Regex(@"\b\d", this.GetRegexOptions());

                var matches = regex.Matches(this.sourceString);

                return matches.Count == CountOfWordsIn(sourceString);
            }
            else if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Any, ExpressionType.Word))
            {
                var regex = new Regex(@"\b\d", this.GetRegexOptions());

                return regex.IsMatch(this.sourceString);
            }
            else if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.FirstN, ExpressionType.Words))
            {
                var count = expressionCallStack.Skip(1).First().Count;
                var expressionBuilder = new StringBuilder(@"^\d");

                for (int i = 0; i < count - 1; i++)
                {
                    expressionBuilder.Append(@"\w*\s\d");
                }

                var regex = new Regex(expressionBuilder.ToString(), this.GetRegexOptions());

                return regex.IsMatch(this.sourceString);
            }

            throw new NotImplementedException();
        }

        private int CountOfWordsIn(string sourceString)
        {
            return sourceString.Split(' ').Count();
        }
    }
}
