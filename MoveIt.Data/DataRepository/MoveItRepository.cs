using MoveIt.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MoveIt.Data.DataRepository
{
    public class MoveItRepository : DbContext
    {
        public MoveItRepository()
        {
        }

        public MoveItRepository(DbContextOptions<MoveItRepository> options) : base(options)
        {
        }

        public DbSet<Classes> Classes { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<ClassRegistrations> ClassRegistrations { get; set; }
        public DbSet<Trainers> Trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BSIATSDISHMAYA\\SQLEXPRESS;Database=MoveIt;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}