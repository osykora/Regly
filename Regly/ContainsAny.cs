using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsAny : ContainsBase, IContainsAny
    {
        public ContainsAny(string sourceString, string expression)
            : base(sourceString, expression)
        {
        }

        public IExecutableExpression Word()
        {
            return this;
        }
    }
}
