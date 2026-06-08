using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Director> Directors => Set<Director>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan"
                },
                new Director
                {
                    Id = 2,
                    Name = "Steven Spielberg"
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    ReleaseYear = 2010,
                    DirectorId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "Jurassic Park",
                    ReleaseYear = 1993,
                    DirectorId = 2
                }
            );
        }
    }
}