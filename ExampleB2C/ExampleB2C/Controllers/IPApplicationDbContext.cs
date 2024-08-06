using ExampleB2C.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleB2C.Controllers
{
    public class IPApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentMetaData> DocumentMetaData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Sessions relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Sessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Documents relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Documents)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Document - DocumentMetadata relationship
            modelBuilder.Entity<Document>()
                .HasMany(d => d.Metadata)
                .WithOne(dm => dm.Document)
                .HasForeignKey(dm => dm.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint on DocumentMetadata (DocumentId, Key)
            modelBuilder.Entity<DocumentMetaData>()
                .HasIndex(dm => new { dm.DocumentId, dm.Key })
                .IsUnique();

        }
    }
}
