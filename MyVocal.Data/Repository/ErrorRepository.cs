using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface IErrorRepository : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}