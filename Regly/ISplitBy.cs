﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly
{
    public interface ISplitBy
    {
        IEnumerable<string> Execute();
    }
}