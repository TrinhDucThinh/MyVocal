using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface ISemanticRepository : IRepository<Semantic>
    {
    }

    public class SemanticRepository : RepositoryBase<Semantic>, ISemanticRepository
    {
        public SemanticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}