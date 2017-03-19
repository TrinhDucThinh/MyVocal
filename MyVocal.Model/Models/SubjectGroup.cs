using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("SubjectGroups")]
    public class SubjectGroup
    {
        [Key]
        public int SubjectGroupId { get; set; }

        [MaxLength(200)]
        [Required]
        public string SubjecGroupName { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Identify { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}