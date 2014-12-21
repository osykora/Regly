﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly.Interfaces
{
    public interface IContains : IExpression
    {
        bool Execute();

        IContains CaseInsensitive();

        IContains CaseSensitive();

        IContains AnyDigit();
    }
}