using System;
using System.Collections.Generic;

namespace MyVocal.Web.Models
{
    public class WordViewModel
    {
        public int WordId { get; set; }

        public string Transcription { get; set; }

        public string WordName { get; set; }

        public int WordCategoryId { get; set; }

        public virtual WordCategoryViewModel WordCategory { get; set; }

        public string Sound { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }

        public int SubjectId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdateBy { get; set; }

        public virtual SubjectViewModel Subject { get; set; }


        public string Meaning { get; set; }

        public string Example { get; set; }

        public string ExampleTranslation { get; set; }

        public string Defination { get; set; }

        public string Synonym { get; set; }

        public virtual IEnumerable<QuestionViewModel> Questions { get; set; }
        public virtual IEnumerable<SemanticViewModel> Semantics { get; set; }

    }
}