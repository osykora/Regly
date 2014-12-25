﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regly.Interfaces
{
    public interface IContainsQuantity
    {
        IContainsEvery Every();

        IContainsAny Any();

        IContainsFirst First();

        IContainsFirstN First(int count);
    }
}
