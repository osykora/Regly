using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsDigit : ContainsBase, IContainsDigit
    {
        public ContainsDigit(string sourceString, string expression)
            : base(sourceString, expression)
        {
        }

        public IContainsValue AtTheBeggining()
        {
            this.expression = "^" + this.expression;

            return new ContainsValue(this.sourceString, this.expression);
        }
    }
}
