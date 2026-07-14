using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Models;

namespace PontosTuristicos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }


        public DbSet<PontoTuristico> PontosTuristicos { get; set; }
    }
}   