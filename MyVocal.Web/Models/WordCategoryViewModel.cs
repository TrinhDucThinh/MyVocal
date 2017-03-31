using System.Collections.Generic;

namespace MyVocal.Web.Models
{
    public class WordCategoryViewModel
    {
        
        public int WordCategoryId { get; set; }

       
        public string CategoryName { get; set; }

       
        public string Description { get; set; }

        
        public string Identify { get; set; }

        public virtual IEnumerable<WordViewModel> Words { get; set; }
    }
}