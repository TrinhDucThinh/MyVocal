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
    public interface IErrorService
    {
        void Create(Error error);
        void SaveChange();
        
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Create(Error error)
        {
            _errorRepository.Add(error);  
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
