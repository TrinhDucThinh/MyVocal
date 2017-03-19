using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        string CreatedBy { get; set; }

        string UpdateBy { get; set; }
    }
}
