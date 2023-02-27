﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Syncer.Data.Entities
{
    public partial class TimeTableDetail : DomainBaseEnitity
    {
        [StringLength(50)]
        public string Day { get; set; }
        public Guid? TimeTableId { get; set; }

        public virtual TimeTable TimeTable { get; set; }
    }
}