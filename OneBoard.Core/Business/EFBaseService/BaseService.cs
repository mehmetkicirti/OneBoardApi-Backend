using OneBoard.Core.DataAccess;
using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Business.EFBaseService
{
    public class BaseService<TDal,TEntity>
        where TDal : IEntityRepository<TEntity>
        where TEntity :class,IEntity,new()
    {

        protected readonly TDal _dal;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(TDal dal, IUnitOfWork unitOfWork)
        {
            _dal = dal;
            _unitOfWork = unitOfWork;
        }
    }
}
