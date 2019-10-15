using OneBoard.Core.DataAccess.EntityFramework;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF._DatabaseContext;
using OneBoard.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.DataAccess.EF
{
    public class EfFirmDal:EfEntityRepositoryBase<Firm,DatabaseContext>,IFirmDal
    {
    }
}
