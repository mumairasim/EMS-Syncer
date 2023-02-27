using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("StudentDiary")]
    public partial class StudentDiary : DomainBaseEnitity
    {
        public StudentDiary()
        {
            ClassStudentDiaries = new HashSet<ClassStudentDiary>();
            StudentStudentDiaries = new HashSet<StudentStudentDiary>();
        }
        public string DiaryText { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }

        public virtual ICollection<ClassStudentDiary> ClassStudentDiaries { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<StudentStudentDiary> StudentStudentDiaries { get; set; }
    }
}