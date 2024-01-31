using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using WebAppMessage.Model;

namespace WebAppMessage
{
    public class MessagesContext : DbContext
    {

        public virtual DbSet<MessagesDB> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(Console.WriteLine)
                .UseNpgsql("Host=127.0.0.1;Port=5432;Database=messagesGB;Username=root;Password=secret;");


        /*
         dotnet ef migrations add InitialCreate --context MessagesContext
         dotnet ef database update
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessagesDB>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("message_pkey");

                entity.ToTable("messages");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.IsReceived)
                    .IsRequired();
            });
        }
    }
}
