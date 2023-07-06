using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TicketApplication.Models;
using TicketApplication.Models.Models;
using TicketApplication.Models.Relationship;

namespace TicketApplication.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment) : base(options)
        {
            _webHostEnvironment = webHostEnvironment;
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
                new Category { Id = 3, Name = "Comedy", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Drama", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Animated", DisplayOrder = 5 }
            );

            string indiana_jones = Path.Combine(_webHostEnvironment.WebRootPath, "seed_images", "indiana_jones.jpg");

            modelBuilder.Entity<Movie>().HasData(
                new Movie {Id=1, Name= "Indiana Jones and the Dial of Destiny", Description = "Daredevil archaeologist Indiana Jones races against time to retrieve a legendary dial that can change the course of history. Accompanied by his goddaughter, he soon finds himself squaring off against Jürgen Voller, a former Nazi who works for NASA.", Duration = 120, ReleaseYear=2023, TicketPrice=15,CategoryId=1,ImageUrl= indiana_jones}
                );
        }
    }
}
