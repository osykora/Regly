using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class Contains : IContains
    {
        // TODO: Rename to ShouldContain
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
            CompareOptions compateOptions = caseSensitive ? CompareOptions.Ordinal : CompareOptions.OrdinalIgnoreCase;

            return CultureInfo.CurrentCulture.CompareInfo.IndexOf(sourceString, word, compateOptions) >= 0;
        }
    }
}
