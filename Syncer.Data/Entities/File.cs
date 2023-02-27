using System.ComponentModel.DataAnnotations.Schema;

namespace Syncer.Data.Entities
{
    [Table("Files")]
    public class File : DomainBaseEnitity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
    }
}