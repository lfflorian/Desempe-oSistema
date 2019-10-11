using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OperationResult
    {
        public bool WasSuccesful { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public OperationResult()
        {
            WasSuccesful = true;
        }
    }
}
