using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Syncer.Data.Entities
{
    public partial class FinanceType : DomainBaseEnitity
    {
        public FinanceType()
        {
            StudentFinanceDetails = new HashSet<StudentFinanceDetail>();
        }

        [StringLength(500)]
        public string Type { get; set; }

        public virtual ICollection<StudentFinanceDetail> StudentFinanceDetails { get; set; }
    }
}