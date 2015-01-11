using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Regly.Extensions;

namespace Regly
{
    public abstract class ContainsBase
    {
        private const string AnyDigit = @"\d";
        private const string BegginingOfString = @"^";
        private const string EndOfString = @"$";
        private const string WordBoundary = @"\b";
        private const string WordCharacter = @"\w";
        private const string Whitespace = @"\s";
        private const string RepeatAnyTimesFewestPossible = "*?";
        private const string PositiveLookAheadTemplate = "(?={0})";
        private const string NegativeLookAheadTemplate = "(?!{0})";
        private const string MatchEmptyString = BegginingOfString + EndOfString;
        private const string MatchNothing = "";
        private const string AnyCharacter = ".";
        private const string AnyCharacterManyTimes = AnyCharacter + RepeatAnyTimesFewestPossible;

        protected Stack<Expression> ExpressionCallStack;
        protected string SourceString;

        protected ContainsBase(string sourceString, Stack<Expression> expressionCallStack)
        {
            SourceString = sourceString;
            ExpressionCallStack = expressionCallStack;
        }

        protected virtual RegexOptions GetRegexOptions()
        {
            return RegexOptions.None;
        }

        public bool Execute()
        {
            string regularExpression = null;

            if (IsStackLike(ExpressionType.ExactValue))
            {
                Expression expression = ExpressionCallStack.Pop();

                regularExpression = GetContainsExactValueExpression(expression.Value);
            }

            if (IsStackLike(ExpressionType.ExactValue, ExpressionType.ButNotValue))
            {
                string notContainsValue = ExpressionCallStack.Pop().Value;
                string containsValue = ExpressionCallStack.Pop().Value;

                regularExpression = GetContainsExactValueExpression(containsValue) +
                                    GetNotContainsExactValueExpression(notContainsValue);
            }

            if (IsStackLike(ExpressionType.ExactValue, ExpressionType.ButNot, ExpressionType.AnyDigit))
            {
                ExpressionCallStack.Pop();
                ExpressionCallStack.Pop();
                string containsValue = ExpressionCallStack.Pop().Value;

                regularExpression = GetContainsExactValueExpression(containsValue) +
                                    GetNotContainsExactValueExpression(AnyDigit);
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
                regularExpression = AnyDigitAtTheBegginingOfFirstNWords(CountOfWordsIn(SourceString));
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
                regularExpression = AnyDigitAnywhereInFirstNWords(CountOfWordsIn(SourceString));
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

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.Last,
                ExpressionType.Word))
            {
                regularExpression = AnyDigitAnywhereInLastNWords(1);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AnywhereIn, ExpressionType.LastN,
                ExpressionType.Words))
            {
                regularExpression = AnyDigitAnywhereInLastNWords(GetCountFromCallstack());
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.Last,
                ExpressionType.Word))
            {
                regularExpression = AnyDigitAtTheBegginingOfLastNWords(1);
            }

            if (IsStackLike(ExpressionType.AnyDigit, ExpressionType.AtTheBegginingOf, ExpressionType.LastN,
                ExpressionType.Words))
            {
                regularExpression = AnyDigitAtTheBegginingOfLastNWords(GetCountFromCallstack());
            }

            var regex = new Regex(regularExpression, GetRegexOptions());

            return regex.IsMatch(SourceString);
        }

        private bool IsStackLike(params ExpressionType[] expressionTypes)
        {
            ExpressionType[] queue = ExpressionCallStack.Reverse().Select(expression => expression.Type).ToArray();

            return queue.SequenceEqual(expressionTypes);
        }

        private string GetContainsExactValueExpression(string exactValue)
        {
            if (exactValue.HasValue())
            {
                return BegginingOfString + PositiveLookAheadTemplate.FillBy(AnyCharacterManyTimes + exactValue);
            }

            return MatchEmptyString;
        }

        private string GetNotContainsExactValueExpression(string exactValue)
        {
            if (exactValue.HasValue())
            {
                return NegativeLookAheadTemplate.FillBy(AnyCharacterManyTimes + exactValue);
            }

            return MatchNothing;
        }

        private static string AnyDigitAtTheBegginingOfLastNWords(int count)
        {
            return "(" + WordBoundary + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}" + EndOfString;
        }

        private static string AnyDigitAnywhereInLastNWords(int count)
        {
            return "(" + WordBoundary + WordCharacter +
                                RepeatAnyTimesFewestPossible + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}" + EndOfString;
        }

        private static string AnyDigitAnywhereInFirstNWords(int count)
        {
            return BegginingOfString + "(" + WordBoundary + WordCharacter +
                                RepeatAnyTimesFewestPossible + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}";
        }

        private static string AnyDigitAtTheBegginingOfFirstNWords(int count)
        {
            return BegginingOfString + "(" + WordBoundary + AnyDigit + WordCharacter +
                                RepeatAnyTimesFewestPossible + WordBoundary + Whitespace +
                                RepeatAnyTimesFewestPossible + "){" + count + "}";
        }

        private int GetCountFromCallstack()
        {
            return ExpressionCallStack.Skip(1).First().Count;
        }

        private static int CountOfWordsIn(string sourceString)
        {
            return sourceString.Split(' ').Count();
        }
    }
}