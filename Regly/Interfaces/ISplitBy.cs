using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regly.Interfaces
{
    public interface ISplitBy
    {
        IEnumerable<string> Execute();
    }
}
