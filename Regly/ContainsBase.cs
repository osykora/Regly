using System.Collections.Generic;
using System.Linq;
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
        private const string RepeatAnyTimesFewestPossible = "*?";

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
            string regularExpression = null;

            if (IsStackLike(ExpressionType.ExactValue))
            {
                Expression expression = expressionCallStack.Pop();

                regularExpression = expression.Value;
            }

            if (IsStackLike(ExpressionType.AnyDigit)
                || IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Any,
                ExpressionType.Word))
            {
                regularExpression = AnyDigit;
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBeggining) ||
                IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.First,
                    ExpressionType.Word))
            {
                regularExpression = AnyDigitAtTheBegginingOfFirstNWords(1);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Every,
                ExpressionType.Word))
            {
                regularExpression = AnyDigitAtTheBegginingOfFirstNWords(CountOfWordsIn(sourceString));
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Any,
                ExpressionType.Word))
            {
                regularExpression = WordBoundary + AnyDigit;
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.FirstN,
                ExpressionType.Words))
            {
                regularExpression = AnyDigitAtTheBegginingOfFirstNWords(GetCountFromCallstack());
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Every,
                ExpressionType.Word))
            {
                regularExpression = AnyDigitAnywhereInFirstNWords(CountOfWordsIn(sourceString));
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.First,
                ExpressionType.Word))
            {
                regularExpression = AnyDigitAnywhereInFirstNWords(1);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.FirstN,
                ExpressionType.Words))
            {
                regularExpression = AnyDigitAnywhereInFirstNWords(GetCountFromCallstack());
            }

            var regex = new Regex(regularExpression, GetRegexOptions());

            return regex.IsMatch(sourceString);
        }

        private string AnyDigitAnywhereInFirstNWords(int count)
        {
            return BegginingOfString + "(" + WordBoundary + WordCharacter +
                                RepeatAnyTimesFewestPossible + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}";
        }

        private string AnyDigitAtTheBegginingOfFirstNWords(int count)
        {
            return BegginingOfString + "(" + WordBoundary + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}";
        }

        private int GetCountFromCallstack()
        {
            return expressionCallStack.Skip(1).First().Count;
        }

        private int CountOfWordsIn(string sourceString)
        {
            return sourceString.Split(' ').Count();
        }
    }
}