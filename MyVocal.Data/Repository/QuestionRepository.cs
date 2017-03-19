using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;

namespace MyVocal.Data.Repository
{
    public interface IQuestionRepository: IRepository<Question>
    {

    }
    public class QuestionRepository : RepositoryBase<Question>
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}