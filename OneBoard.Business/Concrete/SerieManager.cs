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
    public class SerieManager : ISerieService
    {
        private readonly ISerieDal _iSerieDal;

        public SerieManager(ISerieDal iSerieDal)
        {
            _iSerieDal = iSerieDal;
        }
        public IResult Add(Serie entity)
        {
            try
            {
                _iSerieDal.Add(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_ADD);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        public IResult Delete(Serie entity)
        {
            try
            {
                _iSerieDal.Delete(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_DELETE);
            }
            catch (Exception e)
            {

                return new FailResult(e.Message);
            }
        }

        public IDataResult<Serie> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Serie>(_iSerieDal.Get(d => d.ID == Id), BasicCrudOperationMessages.SUCCESS_GET_ID);
            }
            catch (Exception e)
            {

                return new FailDataResult<Serie>(_iSerieDal.Get(d => d.ID == Id), e.Message);
            }
        }

        public IDataResult<IQueryable<Serie>> GetEntityQueryable()
        {
            try
            {
                return new SuccessDataResult<IQueryable<Serie>>(_iSerieDal.GetListByQueryable(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<IQueryable<Serie>>(_iSerieDal.GetListByQueryable(), e.Message);
            }
        }

        public IDataResult<List<Serie>> GetEntityValues()
        {
            try
            {
                return new SuccessDataResult<List<Serie>>(_iSerieDal.GetList().ToList(), BasicCrudOperationMessages.SUCCESS_GET_LİST);
            }
            catch (Exception e)
            {

                return new FailDataResult<List<Serie>>(_iSerieDal.GetList().ToList(), e.Message);
            }
        }

        public IResult Update(Serie entity)
        {
            try
            {
                _iSerieDal.Update(entity);
                return new SuccessResult(BasicCrudOperationMessages.SUCCESS_UPDATE);
            }
            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }
    }
}
