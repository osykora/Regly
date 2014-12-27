using System.Collections.Generic;

namespace Regly.Interfaces
{
    public interface ISplitBy
    {
        IEnumerable<string> Execute();
    }
}