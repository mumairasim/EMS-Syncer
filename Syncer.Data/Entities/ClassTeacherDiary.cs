using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("ClassTeacherDiary")]
    public partial class ClassTeacherDiary : DomainBaseEnitity
    {

        public Guid? TeacherDiaryId { get; set; }

        public Guid? ClassId { get; set; }


        public virtual Class Class { get; set; }

        public virtual TeacherDiary TeacherDiary { get; set; }
    }
}