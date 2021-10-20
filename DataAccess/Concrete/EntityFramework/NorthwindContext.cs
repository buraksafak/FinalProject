using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tablolari ile proje classlarini birbirine baglamak.
    //DbContext, entity framework ile gelen bir base yapi.
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
