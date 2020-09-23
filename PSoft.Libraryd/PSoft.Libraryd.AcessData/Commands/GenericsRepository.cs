﻿using PSoft.Libraryd.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly LibrarydDbContext _context;
        public GenericsRepository(LibrarydDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
