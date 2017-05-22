using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System.Collections.Generic;
using System;

namespace MyVocal.Service
{
    public interface IApplicationUserSubjectService
    {
        ApplicationUser_Subject Add(ApplicationUser_Subject applicationUserSubject);

        void Update(ApplicationUser_Subject applicationUserSubject);

        ApplicationUser_Subject Delete(int id);

        IEnumerable<ApplicationUser_Subject> GetAll();

        bool isLearn(string userId, int subjectId);

        void Save();
    }

    public class ApplicationUserSubjectService : IApplicationUserSubjectService
    {
        private IApplicationUserSubjectRepository _applicationUserSubjectRepository;
        private IUnitOfWork _unitOfWork;

        public ApplicationUserSubjectService(IApplicationUserSubjectRepository applicationUserSubjectRepository, IUnitOfWork unitOfWork)
        {
            _applicationUserSubjectRepository = applicationUserSubjectRepository;
            _unitOfWork = unitOfWork;
        }

        public ApplicationUser_Subject Add(ApplicationUser_Subject applicationUserSubject)
        {
            return _applicationUserSubjectRepository.Add(applicationUserSubject);
        }

        public ApplicationUser_Subject Delete(int id)
        {
           return _applicationUserSubjectRepository.Delete(id);
        }

        public IEnumerable<ApplicationUser_Subject> GetAll()
        {
            return _applicationUserSubjectRepository.GetAll();
        }

        public bool isLearn(string userId, int subjectId)
        {
            return _applicationUserSubjectRepository.isLearn(userId, subjectId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
        public void Update(ApplicationUser_Subject applicationUserSubject)
        {
            _applicationUserSubjectRepository.Update(applicationUserSubject);
        }
    }
}