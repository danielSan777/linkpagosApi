using Microsoft.EntityFrameworkCore;

namespace linkpagosapi.infraestructura.data
{
    public class PagosDbContext : DbContext
    {

        public PagosDbContext(DbContextOptions<PagosDbContext> options)
       : base(options)
        {

        }


        public DbSet<LinkPago> linkPagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }




    }
}
