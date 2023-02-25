using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Class")]
    public partial class Class : DomainBaseEnitity
    {
      
        [Required]
        [StringLength(50)]
        public string ClassName { get; set; }
    }
}
