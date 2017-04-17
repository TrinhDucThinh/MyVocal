using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVocal.Web.Models
{
    public class WordCategoryViewModel
    {
        
        public int WordCategoryId { get; set; }

       [Required]
        public string CategoryName { get; set; }

       
        public string Description { get; set; }

        [Required]
        public string Identify { get; set; }

        public virtual IEnumerable<WordViewModel> Words { get; set; }
    }
}