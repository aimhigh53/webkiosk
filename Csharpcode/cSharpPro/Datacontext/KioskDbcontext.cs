using cSharpPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cSharpPro.Datacontext
{
    public class KioskDbcontext:DbContext
    {
        public DbSet<bagsDB> bagdbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=KioskDb;User Id=sa;Password = ehfwkd53;");
        }

    }
}
