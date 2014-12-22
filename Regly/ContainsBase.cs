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
        protected string sourceString, expression;

        protected virtual RegexOptions GetRegexOptions()
        {
            return RegexOptions.None;
        }

        protected ContainsBase(string sourceString, string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            this.sourceString = sourceString;
            this.expression = expression;
        }

        public string GetExpression()
        {
            return this.expression;
        }

        public bool Execute()
        {
            var regex = new Regex(GetExpression(), GetRegexOptions());

            return regex.IsMatch(this.sourceString);
        }
    }
}
