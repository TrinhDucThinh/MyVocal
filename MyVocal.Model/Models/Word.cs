using MyVocal.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("Words")]
    public class Word:Auditable
    {
        [Key]
        public int WordId { get; set; }

        [MaxLength(40)]
        public string WordName { get; set; }

        [MaxLength(40)]
        public string Transcription { get; set; }

        public int WordCategoryId { get; set; }

        [ForeignKey("WordCategoryId")]
        public virtual WordCategory WordCategory { get; set; }

        [MaxLength(300)]
        public string Sound { get; set; }

        [MaxLength(300)]
        public string Image { get; set; }

        public bool Status { get; set; }

        public int SubjectId { get; set; }

        public string Example { get; set; }

        public string ExampleTranslation { get; set; }

        public string Defination { get; set; }

        public string Synonym { get; set; }

        [MaxLength(400)]
        public string SoundExample { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }
        public virtual IEnumerable<Semantic> Semantics { get; set; }
    }
}