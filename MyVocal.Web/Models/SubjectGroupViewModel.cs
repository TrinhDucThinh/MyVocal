using System.Collections.Generic;

namespace MyVocal.Web.Models
{
    public class SubjectGroupViewModel
    {

        
        public int SubjectGroupId { get; set; }
 
        public string SubjecGroupName { get; set; }

     
        public string Description { get; set; }

      
        public string Identify { get; set; }

       
        public string Image { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<SubjectViewModel> Subjects { get; set; }
    }
}