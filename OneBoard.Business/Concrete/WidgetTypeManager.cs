using OneBoard.Business.Abstract;
using OneBoard.Business.Constants;
using OneBoard.Core.Business;
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
    public class WidgetTypeManager : IWidgetTypeService
    {
        private readonly IWidgetTypeDal _dal;

        public WidgetTypeManager(IWidgetTypeDal _dal)
        {
            this._dal = _dal;
        }

        public IResult Add(WidgetType widget)
        {
            try
            {
                _dal.Add(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }

        }

        public IResult Update(WidgetType widget)
        {
            try
            {
                _dal.Update(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(WidgetType widget)
        {
            try
            {
                _dal.Delete(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

     

        public IDataResult<List<WidgetType>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<WidgetType>>(_dal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch(Exception e)
            {
                return new FailDataResult<List<WidgetType>>(e.Message);
            }
        }

        public IDataResult<WidgetType> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<WidgetType>(_dal.Get(f=>f.ID==Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }

            catch (Exception e)
            {
                return new FailDataResult<WidgetType>(e.Message);
            }
        }

        public IDataResult<IQueryable<WidgetType>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<WidgetType>>(_dal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }

            catch (Exception e)
            {
                return new FailDataResult<IQueryable<WidgetType>>(e.Message);
            }
        }
    }

}
