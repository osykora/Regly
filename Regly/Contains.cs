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

        public Contains(string sourceString)
        {
            this.sourceString = sourceString;
        }

        public IContainsDigit AnyDigit()
        {
            return new ContainsDigit(this.sourceString, @"\d");
        }
    }
}
