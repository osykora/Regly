using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class Regly
    {
        private readonly string sourceString;

        public Regly(string sourceString)
        {
            if (sourceString == null) throw new ArgumentNullException("sourceString");

            this.sourceString = sourceString;
        }

        public IContains Contains(string word)
        {
            return new Contains(sourceString, word);
        }
    }
}
