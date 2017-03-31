using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int Id { set; get; }

        public string Message { set; get; }

        public string StaceTrace { set; get; }

        public DateTime CreateDate { set; get; }
    }
}
