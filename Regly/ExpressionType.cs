using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public enum ExpressionType
    {
        ExactValue,
        AnyDigit,
        AtTheBeggining,
        AtTheBegginingOf,
        Any,
        First,
        FirstN,
        Every,
        Word,
        Words
    }
}
