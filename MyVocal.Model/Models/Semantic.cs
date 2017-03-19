using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("Semantics")]
    public class Semantic
    {
        [Key]
        public int Semantic_Id { get; set; }

        public int WordId { get; set; }

        [ForeignKey("WordId")]
        public virtual Word Word { get; set; }

        [MaxLength(100)]
        public string WordFollow { get; set; }

        [MaxLength(300)]
        public string Example { get; set; }

        [MaxLength(400)]
        public string ExampleSound { get; set; }

        [MaxLength(400)]
        public string Image { get; set; }

        public int? SemamticTime { get; set; }

        public bool? Status { get; set; }
    }
}