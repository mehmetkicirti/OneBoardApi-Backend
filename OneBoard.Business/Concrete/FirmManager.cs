using FluentValidation;
using OneBoard.Business.Abstract;
using OneBoard.Business.ValidationRules._FluentValidation;
using OneBoard.Core.Aspects.Autofac.Validation;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.CrossCuttingCornces.Validation._FluentValidation;
using OneBoard.Core.DataAccess;
using OneBoard.Core.Utilities;
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

    
    public class FirmManager : EfBaseService<IFirmDal, Firm>, IFirmService
    {
        public FirmManager(IFirmDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {

        }


        [ValidationAspect(typeof(FirmValidator),Priority =1)]
        public override IResult AddByVirtualMethod(Firm entity)
        {
            try
            {
               //FluentValidationTool.Validate(new FirmValidator(), entity);
                Dal.Add(entity);

                UnitOfWork.Complete();

                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : {e.Message}");
            }
        }


        [ValidationAspect(typeof(FirmValidator), Priority = 1)]
        public override IResult UpdateByVirtualMethod(Firm entity)
        {
            try
            {
                //FluentValidationTool.Validate(new FirmValidator(), entity);
                Dal.Update(entity);

                UnitOfWork.Complete();

                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult($"{BasicCrudOperationMessages.FAIL_UPDATE} : {e.Message}");
            }
        }






    }
}
