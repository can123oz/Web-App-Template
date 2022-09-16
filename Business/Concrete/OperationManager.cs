using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationManager : IOperationClaimService
    {
        IOperationDal _operation;

        public OperationManager(IOperationDal operation)
        {
            _operation = operation;
        }

       
        public void Add(OperationClaim operationClaim)
        {
            _operation.Add(operationClaim);
        }

        public OperationClaim GetById(int id)
        {
            var result = _operation.Get(p => p.Id == id);
            return result;
        }

        public void Delete(int id)
        {
            var result = _operation.Get(p => p.Id == id);
            _operation.Delete(result);
        }
    }
}
