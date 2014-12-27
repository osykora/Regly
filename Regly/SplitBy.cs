using System.Collections.Generic;
using System.Text.RegularExpressions;
using Regly.Interfaces;

namespace Regly
{
    public class SplitBy : ISplitBy
    {
        private readonly string expression;
        private readonly string sourceString;

        public SplitBy(string sourceString, string expression)
        {
            this.sourceString = sourceString;
            this.expression = expression;
        }

        public IEnumerable<string> Execute()
        {
            if (string.IsNullOrEmpty(expression))
            {
                return new[] {sourceString};
            }
            return Regex.Split(sourceString, expression);
        }
    }
}