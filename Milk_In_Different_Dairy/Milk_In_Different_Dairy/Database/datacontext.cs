using Microsoft.EntityFrameworkCore;
using Milk_In_Different_Dairy.Models;

namespace Milk_In_Different_Dairy.Database
{
    public class datacontext:DbContext
    {


        public datacontext(DbContextOptions options):base(options)
        {

        }

        public DbSet<dairy> Dairys { get; set; }
       public DbSet<Daily_record> Daily_records { get; set; }   
    }
}
