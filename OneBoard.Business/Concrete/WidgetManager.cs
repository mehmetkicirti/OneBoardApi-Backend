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
    public class WidgetManager:IWidgetService
    {
        private readonly IWidgetDal widgetDal;

        public WidgetManager(IWidgetDal dal)
        {
            widgetDal = dal;
        }

        public IResult Add(Widget widget)
        {
            try
            {
                widgetDal.Add(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(Widget widget)
        {
            try
            {
                widgetDal.Delete(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IDataResult<Widget> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Widget>(widgetDal.Get(f=>f.ID==Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {
                return new FailDataResult<Widget>(e.Message);
            }
        }

        public IDataResult<IQueryable<Widget>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Widget>>(widgetDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {
                return new FailDataResult<IQueryable<Widget>>(e.Message);
            }
        }

        public IDataResult<List<Widget>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Widget>>(widgetDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {
                return new FailDataResult<List<Widget>>(e.Message);
            }
        }

    

        public IResult Update(Widget widget)
        {
            try
            {
                widgetDal.Update(widget);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
