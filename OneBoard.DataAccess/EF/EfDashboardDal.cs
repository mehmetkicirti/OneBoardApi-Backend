﻿using System;
using System.Collections.Generic;
using System.Text;
using OneBoard.Core.DataAccess.EntityFramework;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF._DatabaseContext;
using OneBoard.Entities.Concrete;

namespace OneBoard.DataAccess.EF
{
    public class EfDashboardDal : EfEntityRepositoryBase<Dashboard, DatabaseContext>, IDashboardDal
    {
        public EfDashboardDal(DatabaseContext context) : base(context)
        {
        }
    }
}
