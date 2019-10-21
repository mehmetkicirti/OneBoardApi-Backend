using OneBoard.Business.Abstract;
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
    public class DashboardManager : EfBaseService<IDashboardDal, Dashboard>, IDashboardService
    {
        public DashboardManager(IDashboardDal dal, IUnitOfWork unitOfWork) : base(dal, unitOfWork)
        {
        }
    }
}
