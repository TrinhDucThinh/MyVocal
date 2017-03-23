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
    public interface IWordCategoryService
    {
        void Add(WordCategory wordCategory);
        void Update(WordCategory wordCategory);
        void Delete(int id);
        IEnumerable<WordCategory> GetAll();
        WordCategory GetById(int id);
        void SaveChanges();
    }
    public class WordCategoryService : IWordCategoryService
    {
        IWordCategoryRepository _wordCategoryRepository;
        IUnitOfWork _unitOfWork;

        public WordCategoryService(IWordCategoryRepository wordCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._wordCategoryRepository = wordCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(WordCategory wordCategory)
        {
            _wordCategoryRepository.Add(wordCategory);
        }

        public void Delete(int id)
        {
            _wordCategoryRepository.Delete(id);
        }

        public IEnumerable<WordCategory> GetAll()
        {
            return _wordCategoryRepository.GetAll();
        }

        public WordCategory GetById(int id)
        {
            return _wordCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(WordCategory wordCategory)
        {
            _wordCategoryRepository.Update(wordCategory);
        }
    }
}
