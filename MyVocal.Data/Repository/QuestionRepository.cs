using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyVocal.Data.Repository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllByCatetoryPagging(string category, int pageIndex, int pageSize, out int totalRow);
    }

    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Question> GetAllByCatetoryPagging(string category, int pageIndex, int pagesize, out int totalRow)
        {
            var query = from q in DbContext.Questions
                        join qc in DbContext.QuestionCategories
                        on q.QuestionCategoryId equals qc.QuestionCategoryId
                        where qc.QuestionCategoryName == category
                        select q;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pagesize).Take(pagesize);
            return query;
        }
    }
}