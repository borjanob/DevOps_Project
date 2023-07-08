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

        public DbSet<ShowingInOrder> showingsInOrder { get; set; }

        public DbSet<Order> orders { get; set; }

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

            modelBuilder.Entity<Movie>().HasData(
            new Movie {Id=1, Name= "Indiana Jones and the Dial of Destiny", Description = "Daredevil archaeologist Indiana Jones races against time to retrieve a legendary dial that can change the course of history. Accompanied by his goddaughter, he soon finds himself squaring off against Jürgen Voller, a former Nazi who works for NASA.", Duration = 120, ReleaseYear=2023, TicketPrice=15,CategoryId=1,ImageUrl= "/seed_images/indiana_jones.jpg"},
            new Movie {Id = 2, Name = "Spider-Man: Across the Spider-Verse", Description = "After reuniting with Gwen Stacy, Brooklyn's full-time, friendly neighborhood Spider-Man is catapulted across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. However, when the heroes clash on how to handle a new threat, Miles finds himself pitted against the other Spiders. He must soon redefine what it means to be a hero so he can save the people he loves most.", Duration = 120, ReleaseYear = 2023, TicketPrice = 12, CategoryId = 5, ImageUrl = "/seed_images/spider_man.jpg" },
            new Movie { Id = 3, Name = "Barbie", Description = "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", Duration = 120, ReleaseYear = 2023, TicketPrice = 10, CategoryId = 3, ImageUrl = "/seed_images/barbie.jpg" },
            new Movie { Id = 4, Name = "John Wick: Chapter 4", Description = "With the price on his head ever increasing, legendary hit man John Wick takes his fight against the High Table global as he seeks out the most powerful players in the underworld, from New York to Paris to Japan to Berlin.", Duration = 120, ReleaseYear = 2023, TicketPrice = 12, CategoryId = 1, ImageUrl = "/seed_images/john_wick.jpg" },
            new Movie { Id = 5, Name = "Fast X", Description = "Over many missions and against impossible odds, Dom Toretto and his family have outsmarted and outdriven every foe in their path. Now, they must confront the most lethal opponent they've ever faced. Fueled by revenge, a terrifying threat emerges from the shadows of the past to shatter Dom's world and destroy everything -- and everyone -- he loves.", Duration = 120, ReleaseYear = 2023, TicketPrice = 12, CategoryId = 1, ImageUrl = "/seed_images/fax_x.jpg" },
            new Movie { Id = 6, Name = "Oppenheimer", Description = "A feature documentary exploring how one man's brilliance, hubris and relentless drive changed the nature of war forever, led to the deaths of hundreds of thousands of people and unleashed mass hysteria, and how, subsequently, the same man's attempts to co.", Duration = 120, ReleaseYear = 2023, TicketPrice = 15, CategoryId = 4, ImageUrl = "/seed_images/oppenheimer.jpg" }

                );
        }
    }
}
