using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocal.Web.Models
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }

        public string QuestionName { get; set; }

        public int QuestionCategoryId { get; set; }

        public virtual QuestionCategoryViewModel QuestionCategory { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public string Solution { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }

        public int WordId { get; set; }

       
        public virtual WordViewModel Word { get; set; }
    }
}