using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    interface IMST
    {
        IEnumerable<GraphEdge> edges();
        int weight { get;  }
    }
}
