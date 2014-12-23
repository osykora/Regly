using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regly.Interfaces
{
    public interface IContainsEvery : IExecutableExpression
    {
        IExecutableExpression Word();
    }
}
