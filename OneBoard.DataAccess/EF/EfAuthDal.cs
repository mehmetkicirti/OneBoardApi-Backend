using OneBoard.Core.DataAccess.EntityFramework;
using OneBoard.Core.Utilities.Security.Token;
using OneBoard.DataAccess.Abstract;
using OneBoard.DataAccess.EF._DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.DataAccess.EF
{
    public class EfAuthDal : EfEntityRepositoryBase<AccessToken, DatabaseContext>, IAuthDal
    {
        public EfAuthDal(DatabaseContext context) : base(context)
        {
        }
    }
}
