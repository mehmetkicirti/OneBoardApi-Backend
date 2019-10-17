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
    public class DataSourceTypeManager : IDataSourceTypeService
    {
        private readonly IDataSourceTypeDal _iDataSourceTypeDal;

        public DataSourceTypeManager(IDataSourceTypeDal iDataSourceTypeDal)
        {
            _iDataSourceTypeDal = iDataSourceTypeDal;
        }

        public IResult Add(DataSourceType entity)
        {
            try
            {
                _iDataSourceTypeDal.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(DataSourceType entity)
        {
            try
            {
                _iDataSourceTypeDal.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<DataSourceType> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<DataSourceType>(_iDataSourceTypeDal.Get(d => d.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<DataSourceType>(_iDataSourceTypeDal.Get(d => d.ID == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<DataSourceType>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<DataSourceType>>(_iDataSourceTypeDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<DataSourceType>>(_iDataSourceTypeDal.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<DataSourceType>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<DataSourceType>>(_iDataSourceTypeDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<DataSourceType>>(_iDataSourceTypeDal.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(DataSourceType entity)
        {
            try
            {
                _iDataSourceTypeDal.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);

            }
        }
    }
}
