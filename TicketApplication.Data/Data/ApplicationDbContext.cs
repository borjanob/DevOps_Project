using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketApplication.Models;
using TicketApplication.Models.Models;
using TicketApplication.Models.Relationship;

namespace TicketApplication.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<ApplicationUser> applicationUsers { get;set; }

        public DbSet<MovieShowing> movieShowings { get; set; }

        public DbSet<CinemaHall> cinemaHalls { get; set; }

        public DbSet<ShoppingCart> shoppingCarts { get; set; }

        public DbSet<ShowingInShoppingCart> showingsInShoppingCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie {Id=10, Name="Movie 15", Description = "First Movie", Duration = 100, ReleaseYear=2010, TicketPrice=50,CategoryId=4,ImageUrl="" },
                new Movie { Id = 20, Name = "Movie 25", Description = "Second Movie", Duration = 120, ReleaseYear = 2000, TicketPrice = 70, CategoryId = 4, ImageUrl = "" },
                new Movie { Id = 30, Name = "Movie 35", Description = "Third Movie", Duration = 80, ReleaseYear = 2001, TicketPrice = 10, CategoryId = 4, ImageUrl = "" }
                );
        }
    }
}
