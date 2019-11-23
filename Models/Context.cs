using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers {get;set;}
    }
    
}