using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Student")]
    public partial class Student : DomainBaseEnitity
    {
        public Student()
        {
            StudentAssignments = new HashSet<StudentAssignment>();
            StudentFinanceDetails = new HashSet<StudentFinanceDetail>();
            StudentStudentDiaries = new HashSet<StudentStudentDiary>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationNumber { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? ClassId { get; set; }
        public Guid? ImageId { get; set; }



        public virtual Class Class { get; set; }
        public virtual File Image { get; set; }
        public string PreviousSchoolName { get; set; }
        public string ReasonForLeaving { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<StudentAssignment> StudentAssignments { get; set; }

        public virtual ICollection<StudentFinanceDetail> StudentFinanceDetails { get; set; }

        public virtual ICollection<StudentStudentDiary> StudentStudentDiaries { get; set; }

    }
}
