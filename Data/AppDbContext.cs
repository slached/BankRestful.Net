using hangi_kredi_restful.Entities;
using Microsoft.EntityFrameworkCore;
namespace hangi_kredi_restful.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bank> Banks { get; set; }
    }
}
