﻿using System;

namespace Syncer.Data.Entities
{
    public class DomainBaseEnitity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid? SchoolId { get; set; }
        public virtual School School { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string DeletedBy { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
