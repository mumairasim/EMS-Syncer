using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Course")]
    public partial class Course : DomainBaseEnitity
    {
        [Required]
        [StringLength(50)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(250)]
        public string CourseName { get; set; }
    }
}
