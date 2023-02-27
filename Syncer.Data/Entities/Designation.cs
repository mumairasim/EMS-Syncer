using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Designation")]
    public partial class Designation : DomainBaseEnitity
    {
        public Designation()
        {
            Employees = new HashSet<Employee>();
        }

        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}