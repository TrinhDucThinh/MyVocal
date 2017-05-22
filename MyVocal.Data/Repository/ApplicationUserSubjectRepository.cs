using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Data.Repository
{
    public interface IApplicationUserSubjectRepository: IRepository<ApplicationUser_Subject>
    {
        bool isLearn(string userId, int subjectId);
    }
    public class ApplicationUserSubjectRepository : RepositoryBase<ApplicationUser_Subject>, IApplicationUserSubjectRepository
    {
        public ApplicationUserSubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool isLearn(string userId, int subjectId)
        {
            string applicationId= (from item in DbContext.ApplicationUser_Subjects
                        where item.SubjectId==subjectId && item.ApplicationUserId==userId
                        select item.ApplicationUserId).FirstOrDefault();
            if (string.IsNullOrEmpty(applicationId))
            {
                return false;
            }
            return true;
        }
    }
}
