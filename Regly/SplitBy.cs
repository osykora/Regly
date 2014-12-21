using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class SplitBy : ISplitBy
    {
        string sourceString, expression;

        public IEnumerable<string> Execute()
        {
            if (string.IsNullOrEmpty(expression))
            {
                return new[] { sourceString };
            }
            return Regex.Split(sourceString, expression);
        }

        public SplitBy(string sourceString, string expression)
        {
            this.sourceString = sourceString;
            this.expression = expression;
        }
    }
}
