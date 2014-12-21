using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class Contains : IContains
    {
        private readonly string sourceString;
        private readonly string word;
        private bool caseSensitive;

        public Contains(string sourceString, string word)
        {
            //TODO code contracts
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }

            this.sourceString = sourceString;
            this.word = word;

            this.CaseSensitive();
        }

        public IContains CaseInsensitive()
        {
            caseSensitive = false;

            return this;
        }

        public IContains CaseSensitive()
        {
            caseSensitive = true;

            return this;
        }

        public bool Execute()
        {
            RegexOptions options = !caseSensitive ? RegexOptions.IgnoreCase : RegexOptions.None;

            var regex = new Regex(GetExpression(), options);

            return regex.IsMatch(this.sourceString);
        }

        public string GetExpression()
        {
            return word;
        }

        public IContains AnyDigit()
        {
            throw new NotImplementedException();
        }
    }
}
