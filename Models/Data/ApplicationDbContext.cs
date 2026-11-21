using CatalogoCosmeticos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCosmeticos.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cosmetico> Cosmeticos { get; set; }
    }
}