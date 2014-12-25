using Regly.Interfaces;
using System;
using System.Collections.Generic;

namespace Regly
{
    public class Regly : IRegly
    {
        private readonly string sourceString;

        public Regly(string sourceString)
        {
            if (sourceString == null) throw new ArgumentNullException("sourceString");

            this.sourceString = sourceString;
        }

        public IContainsValue Contains(string exactValue)
        {
            if (exactValue == null) throw new ArgumentNullException("exactValue");

            return new ContainsValue(sourceString, new Stack<Expression>(new[] { new Expression(ExpressionType.ExactValue, exactValue) }));
        }

        public IContains Contains()
        {
            return new Contains(sourceString);
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
