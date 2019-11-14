﻿using OneBoard.Business.Abstract;
using OneBoard.Business.ValidationRules._FluentValidation;
using OneBoard.Business.ValidationRules.ForDTOValidation;
using OneBoard.Core.Aspects.Autofac.Validation;
using OneBoard.Core.Business.EFBaseService;
using OneBoard.Core.DataAccess;
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

    [ValidationAspect(typeof(DataSourceTypeValidator))]
    public class DataSourceTypeManager : EfBaseService<IDataSourceTypeDal, DataSourceType>, IDataSourceTypeService
    {
        public DataSourceTypeManager(IDataSourceTypeDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }
    }
}
