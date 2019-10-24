using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess.UnitOfWork
{
    public class UnitOfWork<TContext>:IUnitOfWork
        where TContext:DbContext,new()
    {
        private readonly TContext _context;
        
        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Complete()
        {
               _context.SaveChanges();
        }
    }
}
