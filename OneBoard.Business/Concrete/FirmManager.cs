using OneBoard.Business.Abstract;
using OneBoard.Business.Constants;
using OneBoard.Core.Utilities.Results.Abstract;
using OneBoard.Core.Utilities.Results.Concerete.Data;
using OneBoard.Core.Utilities.Results.Concerete.Result;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneBoard.Business.Concrete
{
    public class FirmManager : IFirmService
    {

        public IFirmDal _dal;

        public FirmManager(IFirmDal dal)
        {
            this._dal = dal;
        }
        public IResult Add(Firm firm)
        {
            _dal.Add(firm);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
        }

        public IResult Delete(Firm firm)
        {
            _dal.Delete(firm);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
        }

        public IDataResult<List<Firm>> GetFirm()
        {
            return new SuccessDataResult<List<Firm>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
        }

        public IResult Update(Firm firm)
        {
            _dal.Update(firm);
            return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
        }
    }
}
