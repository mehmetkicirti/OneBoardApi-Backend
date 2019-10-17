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
    public class DataSourceManager : IDataSourceService
    {
        private readonly IDataSourceDal _iDataSource;

        public DataSourceManager(IDataSourceDal dataSourceDal)
        {
            _iDataSource = dataSourceDal;
        }


        public IResult Add(DataSource entity)
        {
            try
            {
                _iDataSource.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(DataSource entity)
        {
            try
            {
                _iDataSource.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<DataSource> GetById(int Id)
        {

            try
            {
                return new SuccessDataResult<DataSource>(_iDataSource.Get(d => d.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<DataSource>(_iDataSource.Get(d => d.ID == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<DataSource>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<DataSource>>(_iDataSource.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<DataSource>>(_iDataSource.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<DataSource>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<DataSource>>(_iDataSource.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<DataSource>>(_iDataSource.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(DataSource entity)
        {
            try
            {
                _iDataSource.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);

            }
        }
    }
}
