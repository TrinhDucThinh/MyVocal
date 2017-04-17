using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System;
using System.Collections.Generic;

namespace MyVocal.Service
{
    public interface IWordService
    {
        void Add(Word word);

        void Update(Word word);

        void Delete(int id);

        void SaveChange();

        Word GetById(int id);

        IEnumerable<Word> GetAllPagging(int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndexe, int pageSize, out int totalRow);

        //IEnumerable<Word> GetAll(string keyword);
    }

    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;
        private IUnitOfWork _unitOfWork;

        public WordService(IWordRepository wordRepository, IUnitOfWork unitOfWork)
        {
            this._wordRepository = wordRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Word word)
        {
            _wordRepository.Add(word);
        }

        public void Delete(int id)
        {
            _wordRepository.Delete(id);
        }

        public IEnumerable<Word> GetAllPagging(int pageIndex, int pageSize, out int totalRow)
        {
            return _wordRepository.GetMultiPaging(x => x.Status, out totalRow, pageIndex, pageSize, new string[] { "Subject" });
        }

        public IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndex, int pageSize, out int totalRow)
        {
            return _wordRepository.GetBySubjectName(subjectName,pageIndex,pageSize,out totalRow);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Word word)
        {
            _wordRepository.Update(word);
        }

        public Word GetById(int id)
        {
            return _wordRepository.GetSingleById(id);
        }

        //public IEnumerable<Word> GetAll(string keyword)
        //{
        //    //if (!string.IsNullOrEmpty(keyword))
        //    //{
        //    //    return _wordRepository.GetMulti(x=>x.w)
        //    //}else
        //    //{

        //    //}
        //}
    }
}