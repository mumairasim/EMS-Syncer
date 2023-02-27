using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("TeacherDiary")]
    public partial class TeacherDiary : DomainBaseEnitity
    {
        public TeacherDiary()
        {
            ClassTeacherDiaries = new HashSet<ClassTeacherDiary>();
        }
        public string DairyText { get; set; }
        public string Name { get; set; }

        public DateTime? DairyDate { get; set; }

        public Guid? InstructorId { get; set; }

        public virtual ICollection<ClassTeacherDiary> ClassTeacherDiaries { get; set; }

        public virtual Employee Employee { get; set; }
    }
}