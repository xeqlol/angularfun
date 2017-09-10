using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhotoGallery.Entities;

namespace PhotoGallery.Infrastructure
{
    public class PhotoGalleryContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Error> Errors { get; set; }

        public PhotoGalleryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            modelBuilder.Entity<Album>().Property(a => a.Title).HasMaxLength(100);
            modelBuilder.Entity<Album>().Property(a => a.Description).HasMaxLength(500);
            modelBuilder.Entity<Album>().HasMany(a => a.Photos).WithOne(p => p.Album);

            modelBuilder.Entity<Photo>().Property(p => p.Title).HasMaxLength(100);
            modelBuilder.Entity<Photo>().Property(p => p.AlbumId).IsRequired();

            modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(p => p.HashedPassword).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<User>().Property(p => p.Salt).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<UserRole>().Property(p => p.RoleId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(p => p.UserId).IsRequired();

            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
