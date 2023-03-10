using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("LessonPlan")]
    public partial class LessonPlan : DomainBaseEnitity
    {
        public string Text { get; set; }

        public string Name { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
