﻿using Regly.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regly
{
    public class ContainsEvery : ContainsBase, IContainsEvery
    {
        public ContainsEvery(string sourceString, Stack<Expression> expressionCallStack)
            : base(sourceString, expressionCallStack)
        {
        }

        public IExecutableExpression Word()
        {
            expressionCallStack.Push(Expression.Word);

            return this;
        }
    }
}
