using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface ISubjectGroupRepository : IRepository<SubjectGroup>
    {
    }

    public class SubjectGroupRepository : RepositoryBase<SubjectGroup>, ISubjectGroupRepository
    {
        public SubjectGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}