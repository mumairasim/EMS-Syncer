using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    public partial class EmployeeFinanceDetail : DomainBaseEnitity
    {
        public EmployeeFinanceDetail()
        {
            EmployeeFinances = new HashSet<EmployeeFinance>();
        }
        public Guid? EmployeeId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<EmployeeFinance> EmployeeFinances { get; set; }
    }
}