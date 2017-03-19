using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Model.Abstract
{
    public class Auditable :IAuditable
    {
       public DateTime? CreatedDate { get; set; }

       public DateTime? UpdatedDate { get; set; }

       public string CreatedBy { get; set; }

       public string UpdateBy { get; set; }
    }
}
