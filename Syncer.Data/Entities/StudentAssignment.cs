﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("StudentAssignment")]
    public partial class StudentAssignment : DomainBaseEnitity
    {
        public Guid? StudentId { get; set; }

        public Guid? AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public virtual Student Student { get; set; }
    }
}