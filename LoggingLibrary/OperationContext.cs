using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingLibrary
{
    public class OperationContext
    {
        internal List<OperationHolder> Operations { get; set; } = new List<OperationHolder>();
    }
}
