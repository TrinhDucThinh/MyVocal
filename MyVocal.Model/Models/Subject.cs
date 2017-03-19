using MyVocal.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("Subjects")]
    public class Subject:Auditable
    {
        [Key]
        public int SubjectId { get; set; }

        [MaxLength(200)]
        [Required]
        public string SubjectName { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Identify { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        public int SubjectGroupId { get; set; }

        [ForeignKey("SubjectGroupId")]
        public virtual SubjectGroup SubjectGroup { get; set;}
        
        public bool Status { get; set; }

        public int WordTotal { get; set; }
    }
}