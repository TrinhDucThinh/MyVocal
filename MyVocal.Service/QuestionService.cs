using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System.Collections.Generic;

namespace MyVocal.Service
{
    public interface IQuestionService
    {
        Question Add(Question question);

        void Update(Question question);

        Question Delete(int id);

        void Save();

        Question GetById(int id);

        IEnumerable<Question> GetAll();

        IEnumerable<Question> GetAll(string keyword);

        IEnumerable<Question> GetAllPagging(int page, int pageSize, out int totalRow);

        IEnumerable<Question> GetAllByCategoryPagging(string category, int page, int pageSize, out int toltalRow);
    }

    public class QuestionService : IQuestionService
    {
        private IQuestionRepository _questionRepository;
        private IUnitOfWork _unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this._questionRepository = questionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Question Add(Question question)
        {
            return _questionRepository.Add(question);
        }

        public Question Delete(int id)
        {
            return _questionRepository.Delete(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll("QuestionCategory","Word");
        }

        public IEnumerable<Question> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _questionRepository.GetMulti(x => x.QuestionName.Contains(keyword) || x.Word.WordName.Contains(keyword), "QuestionCategory", "Word");
            }
            else
                return _questionRepository.GetAll("QuestionCategory", "Word");
        }

        public IEnumerable<Question> GetAllByCategoryPagging(string category, int pageIndex, int pageSize, out int toltalRow)
        {
            return _questionRepository.GetAllByCatetoryPagging(category, pageIndex, pageSize, out toltalRow);
        }

        public IEnumerable<Question> GetAllPagging(int page, int pageSize, out int totalRow)
        {
            //TO DO SOMETHING
            return _questionRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize, new string[] { "QuestionCategory" });
        }

        public Question GetById(int id)
        {
            return _questionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Question question)
        {
            _questionRepository.Update(question);
        }
    }
}