﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("StudentStudentDiary")]
    public partial class StudentStudentDiary : DomainBaseEnitity
    {
        public Guid? StudentDiaryId { get; set; }

        public Guid? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual StudentDiary StudentDiary { get; set; }
    }
}