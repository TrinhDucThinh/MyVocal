using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System.Collections.Generic;
using System;

namespace MyVocal.Service
{
    public interface IQuestionCategoryService
    {
        QuestionCategory Add(QuestionCategory questionCategory);

        void Update(QuestionCategory questionCategory);

        QuestionCategory Delete(int id);

        IEnumerable<QuestionCategory> GetAll();

        IEnumerable<QuestionCategory> GetAll(string keyword);

        void Save();

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

        public QuestionCategory Add(QuestionCategory questionCategory)
        {
           return _questionCategoryRepository.Add(questionCategory);
        }

        public QuestionCategory Delete(int id)
        {
            return _questionCategoryRepository.Delete(id);
        }

        public IEnumerable<QuestionCategory> GetAll()
        {
            return _questionCategoryRepository.GetAll();
        }

        public IEnumerable<QuestionCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _questionCategoryRepository.GetMulti(x => x.QuestionCategoryName.Contains(keyword));
            }
            else
                return _questionCategoryRepository.GetAll();
        }

        public QuestionCategory GetById(int id)
        {
            return _questionCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(QuestionCategory questionCategory)
        {
             _questionCategoryRepository.Update(questionCategory);
        }
    }
}