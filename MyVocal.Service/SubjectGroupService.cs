using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Service
{
    public class SubjectGroupService
    {
        public interface ISubjectGroupService
        {
            SubjectGroup Add(SubjectGroup questionCategory);

            void Update(SubjectGroup questionCategory);

            SubjectGroup Delete(int id);

            IEnumerable<SubjectGroup> GetAll();

            IEnumerable<SubjectGroup> GetAll(string keyword);

            void Save();

            SubjectGroup GetById(int id);
        }

        public class QuestionCategoryService : ISubjectGroupService
        {
            private ISubjectGroupRepository _subjectGroupRepository;
            private IUnitOfWork _unitOfWork;

            public QuestionCategoryService(ISubjectGroupRepository subjectGroupRepository, IUnitOfWork unitOfWork)
            {
                this._subjectGroupRepository = subjectGroupRepository;
                this._unitOfWork = unitOfWork;
            }

            public SubjectGroup Add(SubjectGroup subjectGroup)
            {
                return _subjectGroupRepository.Add(subjectGroup);
            }

            public SubjectGroup Delete(int id)
            {
               return _subjectGroupRepository.Delete(id);
            }

            public IEnumerable<SubjectGroup> GetAll()
            {
                return _subjectGroupRepository.GetAll();
            }

            public IEnumerable<SubjectGroup> GetAll(string keyword)
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    return _subjectGroupRepository.GetMulti(x => x.SubjecGroupName.Contains(keyword));
                }
                else
                    return _subjectGroupRepository.GetAll();
            }

            public SubjectGroup GetById(int id)
            {
                return _subjectGroupRepository.GetSingleById(id);
            }

            public void Save()
            {
                _unitOfWork.Commit();
            }

            public void Update(SubjectGroup subjectGroup)
            {
                _subjectGroupRepository.Update(subjectGroup);
            }
        }
    }
}
