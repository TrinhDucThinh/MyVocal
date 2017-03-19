using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("QuestionCategories")]
    public class QuestionCategory
    {
        [Key]
        public int QuestionCategoryId { get; set; }

        [MaxLength(200)]
        [Required]
        public string QuesionCategoryName { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }
    }
}