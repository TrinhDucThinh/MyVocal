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
            void Add(SubjectGroup questionCategory);

            void Update(SubjectGroup questionCategory);

            void Delete(int id);

            IEnumerable<SubjectGroup> GetAll();

            void SaveChange();

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

            public void Add(SubjectGroup subjectGroup)
            {
                _subjectGroupRepository.Add(subjectGroup);
            }

            public void Delete(int id)
            {
                _subjectGroupRepository.Delete(id);
            }

            public IEnumerable<SubjectGroup> GetAll()
            {
                return _subjectGroupRepository.GetAll();
            }

            public SubjectGroup GetById(int id)
            {
                return _subjectGroupRepository.GetSingleById(id);
            }

            public void SaveChange()
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
