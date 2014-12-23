using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsDigit : ContainsBase, IContainsDigit
    {
        public ContainsDigit(string sourceString, string expression)
            : base(sourceString, expression)
        {
        }

        public IContainsDigit AtTheBeggining()
        {
            this.expression = "^" + this.expression;

            return new ContainsDigit(this.sourceString, this.expression);
        }

        public IContainsQuantity AtTheBegginingOf()
        {
            this.expression = @"\b\d";

            return new ContainsQuantity(this.sourceString, this.expression);
        }
    }
}
