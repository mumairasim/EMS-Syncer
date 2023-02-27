using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Assignment")]
    public partial class Assignment : DomainBaseEnitity
    {
        public Assignment()
        {
            ClassAssignements = new HashSet<ClassAssignement>();
            StudentAssignments = new HashSet<StudentAssignment>();
        }

        public string AssignmentText { get; set; }

        public DateTime? LastDateOfSubmission { get; set; }

        public Guid? InstructorId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<ClassAssignement> ClassAssignements { get; set; }

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}