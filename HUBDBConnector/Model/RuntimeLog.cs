using System;
using System.Collections.Generic;
using System.Text;

namespace HUBDBConnector.Model
{
    class RuntimeLog
    {
        public RuntimeLog()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
