namespace MyVocal.Web.Models
{
    public class SubjectViewModel
    {
       
        public int SubjectId { get; set; }

       
        public string SubjectName { get; set; }

       
        public string Description { get; set; }

       
        public string Identify { get; set; }

      
        public string Image { get; set; }

        public int SubjectGroupId { get; set; }

       
        public virtual SubjectGroupViewModel SubjectGroup { get; set; }

        public bool Status { get; set; }

        public bool isLearn { get; set; }

        public int WordTotal { get; set; }
    }
}