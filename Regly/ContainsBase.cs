using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Regly
{
    public abstract class ContainsBase
    {
        private const string AnyDigit = @"\d";
        private const string BegginingOfString = @"^";
        private const string WordBoundary = @"\b";
        private const string WordCharacter = @"\w";
        private const string Whitespace = @"\s";
        private const string RepeatAnyTimes = "*";
        private const string RepeatAnyTimesFewestPossible = "*?";
        private const string AnyCharacter = ".";

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
                var regex = new Regex(AnyDigit, GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBeggining) ||
                IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.First,
                    ExpressionType.Word))
            {
                var regex = new Regex(BegginingOfString + AnyDigit, GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Every,
                ExpressionType.Word))
            {
                var regex = new Regex(WordBoundary + AnyDigit, GetRegexOptions());

                MatchCollection matches = regex.Matches(sourceString);

                return matches.Count == CountOfWordsIn(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Any,
                ExpressionType.Word))
            {
                var regex = new Regex(WordBoundary + AnyDigit, GetRegexOptions());

                return regex.IsMatch(sourceString);
            }
            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.FirstN,
                ExpressionType.Words))
            {
                int count = expressionCallStack.Skip(1).First().Count;
                var expressionBuilder = new StringBuilder(BegginingOfString + AnyDigit);

                for (int i = 0; i < count - 1; i++)
                {
                    expressionBuilder.Append(WordCharacter + RepeatAnyTimes + Whitespace + AnyDigit);
                }

                var regex = new Regex(expressionBuilder.ToString(), GetRegexOptions());

                return regex.IsMatch(sourceString);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Every,
                ExpressionType.Word))
            {
                var regex = new Regex("(" + WordBoundary + WordCharacter + RepeatAnyTimesFewestPossible + AnyDigit + AnyCharacter + RepeatAnyTimesFewestPossible + "){" + CountOfWordsIn(sourceString) + "}", GetRegexOptions());

                return regex.IsMatch(sourceString);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.First,
                ExpressionType.Word))
            {
                var regex = new Regex(BegginingOfString + WordBoundary + WordCharacter + RepeatAnyTimesFewestPossible + AnyDigit + WordCharacter + RepeatAnyTimesFewestPossible + WordBoundary);

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