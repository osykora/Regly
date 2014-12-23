using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsEvery : ContainsBase, IContainsEvery
    {
        public ContainsEvery(string sourceString, string expression)
            : base(sourceString, expression)
        {
        }

        public IExecutableExpression Word()
        {
            return this;
        }

        protected override bool ExecuteInternal()
        {
            var regex = new Regex(this.GetExpression(), this.GetRegexOptions());

            var matches = regex.Matches(this.sourceString);

            return matches.Count == CountOfWordsIn(sourceString);
        }

        private int CountOfWordsIn(string sourceString)
        {
            return sourceString.Split(' ').Count();
        }
    }
}
