using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(
            DbContextOptions options) : 
            base(options)
        {
        }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

    }
}
