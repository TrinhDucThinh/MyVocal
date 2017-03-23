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
        void Add(Subject subject);
        void Update(Subject subject);
        void Delete(int id);
        void SaveChange();
        IEnumerable<Subject> GetAll();
        IEnumerable<Subject> GetAllPagging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Subject> GetBySubjectGroup(string subjectGroupName, int pageIndex, int pageSize, out int totalRow);
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

        public void Add(Subject subject)
        {
            _subjectRepository.Add(subject);
        }

        public void Delete(int id)
        {
            _subjectRepository.Delete(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public IEnumerable<Subject> GetAllPagging(int pageIndex, int pageSize, out int totalRow)
        {
            return _subjectRepository.GetMultiPaging(x=>x.Status,out totalRow,pageIndex, pageSize,new string[] { "SubjectGroup" });
        }

        public IEnumerable<Subject> GetBySubjectGroup(string subjectGroupName, int pageIndex, int pageSize, out int totalRow)
        {
            return _subjectRepository.GetAllBySubjectGroup(subjectGroupName, pageIndex, pageSize, out totalRow);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Subject subject)
        {
            _subjectRepository.Update(subject);
        }
    }
}
