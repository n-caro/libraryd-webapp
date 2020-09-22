using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData
{
    class LibrarydDbContext : DbContext
    {
        // add DBset here
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=LibrarydDBdev;Trusted_Connection=True;");
        }
    }
}
