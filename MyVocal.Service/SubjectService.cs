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
    public interface ISubjectService
    {
        Subject Add(Subject subject);
        void Update(Subject subject);
        Subject Delete(int id);
        void Save();
        IEnumerable<Subject> GetAll(string keyword);
     
        IEnumerable<Subject> GetAllBySubjectId(int subjectGroupId);
        Subject GetById(int id);
        //IEnumerable<Question> GetAllPagging(int page, int pageSize, out int totalRow);
        IEnumerable<Subject> GetAll();
       
        IEnumerable<Subject> GetBySubjectGroup(string subjectGroupName, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Subject> GetByGroupId(int groupId, int pageIndex, int pageSize, out int totalRow);
    }
    public class SubjectService : ISubjectService
    {
        ISubjectRepository _subjectRepository;
        IUnitOfWork _unitOfWork;

        public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            this._subjectRepository = subjectRepository;
            this._unitOfWork = unitOfWork;
        }

        public Subject Add(Subject subject)
        {
            return _subjectRepository.Add(subject);
        }

        public Subject Delete(int id)
        {
            return _subjectRepository.Delete(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public IEnumerable<Subject> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _subjectRepository.GetMulti(x => x.SubjectName.Contains(keyword), "SubjectGroup");
            }
            else
                return _subjectRepository.GetAll("SubjectGroup");
        }

        public IEnumerable<Subject> GetAllBySubjectId(int subjectGroupId)
        {
            return _subjectRepository.GetAllBySubjectId(subjectGroupId);
        }

        public IEnumerable<Subject> GetByGroupId(int groupId, int pageIndex, int pageSize, out int totalRow)
        {
            return _subjectRepository.GetAllByGroup(groupId, pageIndex, pageSize, out totalRow);
        }

        public Subject GetById(int id)
        {
            return _subjectRepository.GetSingleById(id);
        }

        public IEnumerable<Subject> GetBySubjectGroup(string subjectGroupName, int pageIndex, int pageSize, out int totalRow)
        {
            return _subjectRepository.GetAllBySubjectGroup(subjectGroupName, pageIndex, pageSize, out totalRow);
        }

       
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Subject subject)
        {
            _subjectRepository.Update(subject);
        }
    }
}
