using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsQuantity : ContainsBase, IContainsQuantity
    {
        public ContainsQuantity(string sourceString, string expression)
            : base(sourceString, expression)
        {
        }

        public IContainsEvery Every()
        {
            return new ContainsEvery(this.sourceString, this.expression);
        }
    }
}
