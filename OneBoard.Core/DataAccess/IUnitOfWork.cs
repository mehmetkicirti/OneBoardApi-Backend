using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Complete();
    }
}
