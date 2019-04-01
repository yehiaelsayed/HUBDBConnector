using System;
using System.Collections.Generic;
using System.Text;

namespace HUBDBConnector.Model
{
    public class FaildUserLog
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public Guid UserTenantId { get; set; }

        public String UserFullName { get; set; }
    }
}
