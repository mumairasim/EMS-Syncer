using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    public partial class StudentFinanceDetail : DomainBaseEnitity
    {
        public StudentFinanceDetail()
        {
            Student_Finances = new HashSet<Student_Finances>();
        }
        public Guid? StudentId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }
        [Column(TypeName = "money")]
        public decimal? Arears { get; set; }

        public Guid? FinanceTypeId { get; set; }

        public virtual FinanceType FinanceType { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<Student_Finances> Student_Finances { get; set; }
    }
}