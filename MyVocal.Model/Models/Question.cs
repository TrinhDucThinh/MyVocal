using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocal.Model.Models
{
    [Table("Questions")]
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionName { get; set; }
   
        public int QuestionCategoryId { get; set; }

        [ForeignKey("QuestionCategoryId")]
        public virtual QuestionCategory QuestionCategory { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public string Solution { get; set; }

        public string Image { get; set; }

        public string Audio { get; set; }

        public bool Status { get; set; }

        public int WordId { get; set; }

        [ForeignKey("WordId")]
        public virtual Word Word { get; set; }

    }
}