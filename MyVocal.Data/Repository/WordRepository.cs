using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyVocal.Data.Repository
{
    public interface IWordRepository : IRepository<Word>
    {
        IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndex, int pageSize, out int totalRow);
    }

    public class WordRepository : RepositoryBase<Word>, IWordRepository
    {
        public WordRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from w in DbContext.Words
                        join s in DbContext.Subjects
                        on w.SubjectId equals s.SubjectId
                        where s.SubjectName == subjectName
                        select w;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Skip(pageSize);
            return query;
        }
    }
}