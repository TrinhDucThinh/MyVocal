using System;
using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyVocal.Data.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetAllBySubjectGroup(string subjecGroupName, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Subject> GetAllByGroup(int groupId, int pageIndex, int pageSize, out int totalRow);

    }

    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Subject> GetAllByGroup(int groupId, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from s in DbContext.Subjects
                        join sg in DbContext.SubjectGroups
                        on s.SubjectGroupId equals sg.SubjectGroupId
                        where sg.SubjectGroupId == groupId
                        orderby s.SubjectId
                        select s;
            totalRow = query.Count();
            
            var result=query.Skip((pageIndex-1)*pageSize).Take(pageSize);
            return result;

        }

        public IEnumerable<Subject> GetAllBySubjectGroup(string subjecGroupName, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from s in DbContext.Subjects
                        join sg in DbContext.SubjectGroups
                        on s.SubjectGroupId equals sg.SubjectGroupId
                        where sg.SubjecGroupName == subjecGroupName
                        select s;
            totalRow = query.Count();
            query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}