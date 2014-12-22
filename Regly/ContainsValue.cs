using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsValue : ContainsBase, IContainsValue
    {
        private bool caseSensitive;

        protected override RegexOptions GetRegexOptions()
        {
            return !caseSensitive ? RegexOptions.IgnoreCase : RegexOptions.None;
        }

        public ContainsValue(string sourceString, string expression)
            : base(sourceString, expression)
        {
            this.CaseSensitive();
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

        public IContainsValue AtTheBeggining()
        {
            this.expression = "^" + this.expression;

            return this;
        }
    }
}
