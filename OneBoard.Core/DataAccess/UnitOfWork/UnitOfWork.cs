﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneBoard.Core.DataAccess.UnitOfWork
{
    public class UnitOfWork<TContext>: IUnitOfWork
        where TContext : DbContext,new()
    {
        private readonly TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
               await _context.SaveChangesAsync();

        }
        public void Complete()
        {
               _context.SaveChanges();
        }
    }
}
