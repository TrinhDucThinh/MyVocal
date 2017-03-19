using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface IWordRepository : IRepository<Word> { }

    public class WordRepository : RepositoryBase<Word>, IWordRepository
    {
        public WordRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}