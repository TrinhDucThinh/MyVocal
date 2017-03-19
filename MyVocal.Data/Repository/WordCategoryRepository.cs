using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface IWordCategoryRepository : IRepository<WordCategory> { }

    internal class WordCategoryRepository : RepositoryBase<WordCategory>, IWordCategoryRepository
    {
        public WordCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}