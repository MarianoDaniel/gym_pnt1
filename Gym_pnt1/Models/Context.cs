using Gym_pnt1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gym_pnt1.Models
{
    public class Context : DbContext
    {
        public DbSet<Gym> Gym { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = DESKTOP-7B7S35I; Initial Catalog=GymDB; " +
                "Integrated Security=true; Encrypt=True; TrustServerCertificate=true");

        }
    }
}
