using Microsoft.EntityFrameworkCore;
using milk_in_liters_api.model;

namespace milk_in_liters_api.database
{
    public class datacontext:DbContext
    {
      

        public datacontext(DbContextOptions<datacontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<member> members { get; set; }
        public DbSet<milk> milks { get; set; }
       
    }
}
