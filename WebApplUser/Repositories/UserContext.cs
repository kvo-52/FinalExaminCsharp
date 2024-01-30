using System.Collections.Generic;
using System.Reflection.Emit;
using WebAppUser.Repositories.DTO;
using Microsoft.EntityFrameworkCore;

namespace WebAppUser.Repositories
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(Console.WriteLine)
                .UseNpgsql("Host=127.0.0.1;Port=5432;Database=postgres;Username=root;Password=secret;");

        /*
         dotnet ef migrations add InitialCreate --context UserContext
         dotnet ef database update
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");
                entity.HasIndex(e => e.Name).IsUnique();

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.Salt).HasColumnName("salt");

                entity.Property(e => e.RoleId).HasConversion<int>();
            });

            modelBuilder
                .Entity<Role>()
                .Property(e => e.RoleId)
                .HasConversion<int>();

            modelBuilder
                .Entity<Role>().HasData(
                    Enum.GetValues(typeof(RoleId))
                        .Cast<RoleId>()
                        .Select(e => new Role()
                        {
                            RoleId = e,
                            Name = e.ToString()
                        }));
        }
    }
}
