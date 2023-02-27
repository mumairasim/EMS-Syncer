using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Employee")]
    public partial class Employee : DomainBaseEnitity
    {
        public Employee()
        {
            Assignments = new HashSet<Assignment>();
            EmployeeFinanceDetails = new HashSet<EmployeeFinanceDetail>();
            StudentDiaries = new HashSet<StudentDiary>();
            TeacherDiaries = new HashSet<TeacherDiary>();
            Periods = new HashSet<Period>();
            Worksheets = new HashSet<Worksheet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EmployeeNumber { get; set; }

        public Guid? PersonId { get; set; }

        public Guid? DesignationId { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<EmployeeFinanceDetail> EmployeeFinanceDetails { get; set; }

        public virtual ICollection<StudentDiary> StudentDiaries { get; set; }

        public virtual ICollection<TeacherDiary> TeacherDiaries { get; set; }

        public virtual ICollection<Period> Periods { get; set; }

        public virtual ICollection<Worksheet> Worksheets { get; set; }
    }
}