using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System.Collections.Generic;

namespace MyVocal.Service
{
    public interface IQuestionCategoryService
    {
        void Add(QuestionCategory questionCategory);

        void Update(QuestionCategory questionCategory);

        void Delete(int id);

        IEnumerable<QuestionCategory> GetAll();

        void SaveChange();

        QuestionCategory GetById(int id);
    }

    public class QuestionCategoryService : IQuestionCategoryService
    {
        private IQuestionCategoryRepository _questionCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public QuestionCategoryService(IQuestionCategoryRepository questionCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._questionCategoryRepository = questionCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(QuestionCategory questionCategory)
        {
            _questionCategoryRepository.Add(questionCategory);
        }

        public void Delete(int id)
        {
            _questionCategoryRepository.Delete(id);
        }

        public IEnumerable<QuestionCategory> GetAll()
        {
            return _questionCategoryRepository.GetAll();
        }

        public QuestionCategory GetById(int id)
        {
            return _questionCategoryRepository.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(QuestionCategory questionCategory)
        {
            _questionCategoryRepository.Update(questionCategory);
        }
    }
}