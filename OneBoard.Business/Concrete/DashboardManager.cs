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
    public class DashboardManager : IDashboardService
    {
        private readonly IDashboardDal _iDashboard;
        public DashboardManager(IDashboardDal iDashboard)
        {
            _iDashboard = iDashboard;
        }
        public IResult Add(Dashboard entity)
        {
            try
            {
                _iDashboard.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }

        }

        public IResult Delete(Dashboard entity)
        {
            try
            {
                _iDashboard.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<Dashboard> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Dashboard>(_iDashboard.Get(d => d.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<Dashboard>(_iDashboard.Get(d => d.ID == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<Dashboard>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Dashboard>>(_iDashboard.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<Dashboard>>(_iDashboard.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<Dashboard>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Dashboard>>(_iDashboard.GetList().ToList(),BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<Dashboard>>(_iDashboard.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(Dashboard entity)
        {
            try
            {
                _iDashboard.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
