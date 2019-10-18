﻿using OneBoard.Business.Abstract;
using OneBoard.Core.Business.EFBaseService;
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
    public class UserFirmManager : EfBaseService<IUserFirmDal, UserFirm>, IUserFirmService
    {
        public UserFirmManager(IUserFirmDal dal) : base(dal)
        {
        }
    }
}
