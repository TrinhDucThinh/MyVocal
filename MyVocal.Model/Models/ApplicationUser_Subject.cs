using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("ApplicationUser_Subject")]
    public class ApplicationUser_Subject
    {
        [Key]
        [Column(Order = 1)]
        public int SubjectId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public int WordRememebered { get; set; }

        public int NotWordRemembered { get; set; }

        public DateTime LearnDate { get; set; }

        public string ListWordIdRememebered { get; set; }

        public string ListNotWordIdRememebered { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser User { set; get; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { set; get; }

    }
}