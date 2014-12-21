using Regly.Interfaces;
using System;

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

        public ISplitBy SplitBy(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return new SplitBy(sourceString, expression);
        }
    }
}
