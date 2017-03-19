using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface IQuestionCategoryRepository : IRepository<QuestionCategory>
    {
    }

    public class QuestionCategoryRepository : RepositoryBase<QuestionCategory>, IQuestionCategoryRepository
    {
        public QuestionCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}