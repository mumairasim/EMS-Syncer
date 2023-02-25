using Syncer.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syncer.Data.Entities
{
    public class BaseEntity
    {
        public RequestStatus? ApprovalStatus { get; set; }
        public bool? IsSent { get; set; } = false;
    }
}
