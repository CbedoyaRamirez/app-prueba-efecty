using api_prueba_efecty.Models;
using Microsoft.EntityFrameworkCore;

namespace api_prueba_efecty.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }

        public DbSet<DataPersona> DataPersona { get; set; }

    }
}
