using System.Collections.Generic;

namespace MyVocal.Web.Models
{
    public class QuestionCategoryViewModel
    {
      
        public int QuestionCategoryId { get; set; }

        public string QuestionCategoryName { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}