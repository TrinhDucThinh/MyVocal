using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Model.Models
{
    [Table("WordCategories")]
    public class WordCategory
    {
        [Key]
        public int WordCategoryId { get; set; }

        [MaxLength(15)]
        public string CategoryName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(15)]
        public string Identify { get; set; }

        public virtual IEnumerable<Word> Words { get; set; }
    }
}
