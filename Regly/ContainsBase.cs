using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Regly
{
    public abstract class ContainsBase
    {
        protected Stack<Expression> expressionCallStack;
        protected string sourceString;

        protected ContainsBase(string sourceString, Stack<Expression> expressionCallStack)
        {
            this.sourceString = sourceString;
            this.expressionCallStack = expressionCallStack;
        }

        protected virtual RegexOptions GetRegexOptions()
        {
            return RegexOptions.None;
        }

        private bool IsStackLike(params ExpressionType[] expressionTypes)
        {
            ExpressionType[] queue = expressionCallStack.Reverse().Select(expression => expression.Type).ToArray();

            return queue.SequenceEqual(expressionTypes);
        }

        public bool Execute()
        {
            if (IsStackLike(ExpressionType.ExactValue))
            {
                Expression expression = expressionCallStack.Pop();
                var regex = new Regex(expression.Value, GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit)
                || IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Any,
                ExpressionType.Word))
            {
                var regex = new Regex(@"\d", GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBeggining) ||
                IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.First,
                    ExpressionType.Word))
            {
                var regex = new Regex(@"^\d", GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Every,
                ExpressionType.Word))
            {
                var regex = new Regex(@"\b\d", GetRegexOptions());

                MatchCollection matches = regex.Matches(sourceString);

                return matches.Count == CountOfWordsIn(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Any,
                ExpressionType.Word))
            {
                var regex = new Regex(@"\b\d", GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.FirstN,
                ExpressionType.Words))
            {
                int count = expressionCallStack.Skip(1).First().Count;
                var expressionBuilder = new StringBuilder(@"^\d");

                for (int i = 0; i < count - 1; i++)
                {
                    expressionBuilder.Append(@"\w*\s\d");
                }

                var regex = new Regex(expressionBuilder.ToString(), GetRegexOptions());

                return regex.IsMatch(sourceString);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Every,
                ExpressionType.Word))
            {
                var regex = new Regex(@"(\b\w*?\d.*?){" + CountOfWordsIn(sourceString) + "}", GetRegexOptions());
                
                return regex.IsMatch(sourceString);
            }

            throw new NotImplementedException();
        }

        private int CountOfWordsIn(string sourceString)
        {
            return sourceString.Split(' ').Count();
        }
    }
}