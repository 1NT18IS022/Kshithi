using Microsoft.EntityFrameworkCore;
using Sales.models;

namespace Sales.Database
{
    public class datacontext:DbContext
    {

        public datacontext(DbContextOptions options):base(options)
        {

        }
     

        public DbSet<sales> sales { get; set; }
    }
}
