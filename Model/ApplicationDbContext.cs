using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceClients.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Service> Service { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                var converter = new EnumToNumberConverter<Status, int>();
                entity.Property(e => e.Status)
                 .HasConversion(converter);
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                var converterProfession = new EnumToNumberConverter<Profession, int>();
                entity.Property(e => e.Profession)
                 .HasConversion(converterProfession);
            });
        }
    } 
}
