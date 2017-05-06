using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System;
using System.Collections.Generic;

namespace MyVocal.Service
{
    public interface IWordService
    {
        Word Add(Word word);

        void Update(Word word);

        Word Delete(int id);

        void Save();

        Word GetById(int id);

        IEnumerable<Word> GetAllPagging(int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndex, int pageSize, out int totalRow);

        IEnumerable<Word> GetAllBySubjectId(int subjectId);

        IEnumerable<Word> GetAll(string keyword);
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

        public Word Add(Word word)
        {
            return _wordRepository.Add(word);
        }

        public Word Delete(int id)
        {
            return _wordRepository.Delete(id);
        }

        public IEnumerable<Word> GetAllPagging(int pageIndex, int pageSize, out int totalRow)
        {
            return _wordRepository.GetMultiPaging(x => x.Status, out totalRow, pageIndex, pageSize, new string[] { "Subject" });
        }

        public IEnumerable<Word> GetBySubjectName(string subjectName, int pageIndex, int pageSize, out int totalRow)
        {
            return _wordRepository.GetBySubjectName(subjectName,pageIndex,pageSize,out totalRow);
        }

        public void Save()
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

        public IEnumerable<Word> GetAllBySubjectId(int subjectId)
        {
            return _wordRepository.GetAllBySubjectId(subjectId);
        }

        public IEnumerable<Word> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _wordRepository.GetMulti(x => x.WordName.Contains(keyword));
            }else
            {
                return _wordRepository.GetAll();
            }
        }
    }
}