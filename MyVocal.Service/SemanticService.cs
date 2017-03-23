using MyVocal.Data.Infrastructure;
using MyVocal.Data.Repository;
using MyVocal.Model.Models;
using System.Collections.Generic;

namespace MyVocal.Service
{
    public interface ISemanticService
    {
        void Add(Semantic semantic);

        void Update(Semantic semantic);

        void Delete(int id);

        IEnumerable<Semantic> GetAll();

        void SaveChange();
    }

    public class SemanticService : ISemanticService
    {
        private ISemanticRepository _semanticRepository;
        private IUnitOfWork _unitOfWork;

        public SemanticService(ISemanticRepository semanticRepository, IUnitOfWork unitOfWork)
        {
            this._semanticRepository = semanticRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Semantic semantic)
        {
            _semanticRepository.Add(semantic);
        }

        public void Delete(int id)
        {
            _semanticRepository.Delete(id);
        }

        public IEnumerable<Semantic> GetAll()
        {
            return _semanticRepository.GetAll();
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Semantic semantic)
        {
            _semanticRepository.Update(semantic);
        }
    }
}