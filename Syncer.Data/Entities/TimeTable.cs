using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("TimeTable")]
    public partial class TimeTable : DomainBaseEnitity
    {
        public TimeTable()
        {
        }

        [StringLength(500)]
        public string TimeTableName { get; set; }
        public Guid? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}