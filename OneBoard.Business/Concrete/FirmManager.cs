﻿using OneBoard.Business.Abstract;
using OneBoard.Business.ValidationRules._FluentValidation;
using OneBoard.Core.Aspects.Autofac.Logging;
using OneBoard.Core.Aspects.Autofac.Validation;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.CrossCuttingCornces.Logging.Log4Net.Loggers;
using OneBoard.Core.DataAccess;
using OneBoard.DataAccess.Abstract;
using OneBoard.Entities.Concrete;

namespace OneBoard.Business.Concrete
{

    [LogAspect(typeof(DatabaseLogger))]
    [ValidationAspect(typeof(FirmValidator))]
    
    public class FirmManager : EfBaseService<IFirmDal, Firm>, IFirmService
    {
        public FirmManager(IFirmDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }




        //public override IResult AddByVirtualMethod(Firm entity)
       // {
              // try
                //{
                   //FluentValidationTool.Validate(new FirmValidator(), entity);
                   // _dal.Add(entity);

            //        _unitOfWork.Complete();

            //        return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            //    }

            //    catch (Exception e)
            //    {
            //        return new FailResult($"{BasicCrudOperationMessages.FAIL_ADD} : {e.Message}");
            //    }
            //}


            //[ValidationAspect(typeof(FirmValidator), Priority = 1)]
            //public override IResult UpdateByVirtualMethod(Firm entity)
            //{
            //    try
            //    {
            //        FluentValidationTool.Validate(new FirmValidator(), entity);
            //        _dal.Update(entity);

            //        _unitOfWork.Complete();

            //        return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            //    }

            //    catch (Exception e)
            //    {
            //        return new FailResult($"{BasicCrudOperationMessages.FAIL_UPDATE} :");
            //    }
            //}




        }

    }

