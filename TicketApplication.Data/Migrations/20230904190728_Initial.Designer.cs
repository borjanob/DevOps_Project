﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketApplication.Data.Data;

#nullable disable

namespace TicketApplication.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230904190728_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TicketApplication.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Animated"
                        });
                });

            modelBuilder.Entity("TicketApplication.Models.Models.CinemaHall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("cinemaHalls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 150,
                            Name = "Cinema hall 1"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 100,
                            Name = "Cinema hall 2"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 200,
                            Name = "Cinema hall 3"
                        });
                });

            modelBuilder.Entity("TicketApplication.Models.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Daredevil archaeologist Indiana Jones races against time to retrieve a legendary dial that can change the course of history. Accompanied by his goddaughter, he soon finds himself squaring off against Jürgen Voller, a former Nazi who works for NASA.",
                            Duration = 120,
                            ImageUrl = "/seed_images/indiana_jones.jpg",
                            Name = "Indiana Jones and the Dial of Destiny",
                            ReleaseYear = 2023,
                            TicketPrice = 15.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            Description = "After reuniting with Gwen Stacy, Brooklyn's full-time, friendly neighborhood Spider-Man is catapulted across the Multiverse, where he encounters a team of Spider-People charged with protecting its very existence. However, when the heroes clash on how to handle a new threat, Miles finds himself pitted against the other Spiders. He must soon redefine what it means to be a hero so he can save the people he loves most.",
                            Duration = 120,
                            ImageUrl = "/seed_images/spider_man.jpg",
                            Name = "Spider-Man: Across the Spider-Verse",
                            ReleaseYear = 2023,
                            TicketPrice = 12.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.",
                            Duration = 120,
                            ImageUrl = "/seed_images/barbie.jpg",
                            Name = "Barbie",
                            ReleaseYear = 2023,
                            TicketPrice = 10.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Description = "With the price on his head ever increasing, legendary hit man John Wick takes his fight against the High Table global as he seeks out the most powerful players in the underworld, from New York to Paris to Japan to Berlin.",
                            Duration = 120,
                            ImageUrl = "/seed_images/john_wick.jpg",
                            Name = "John Wick: Chapter 4",
                            ReleaseYear = 2023,
                            TicketPrice = 12.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Description = "Over many missions and against impossible odds, Dom Toretto and his family have outsmarted and outdriven every foe in their path. Now, they must confront the most lethal opponent they've ever faced. Fueled by revenge, a terrifying threat emerges from the shadows of the past to shatter Dom's world and destroy everything -- and everyone -- he loves.",
                            Duration = 120,
                            ImageUrl = "/seed_images/fax_x.jpg",
                            Name = "Fast X",
                            ReleaseYear = 2023,
                            TicketPrice = 12.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Description = "A feature documentary exploring how one man's brilliance, hubris and relentless drive changed the nature of war forever, led to the deaths of hundreds of thousands of people and unleashed mass hysteria, and how, subsequently, the same man's attempts to co.",
                            Duration = 120,
                            ImageUrl = "/seed_images/oppenheimer.jpg",
                            Name = "Oppenheimer",
                            ReleaseYear = 2023,
                            TicketPrice = 15.0
                        });
                });

            modelBuilder.Entity("TicketApplication.Models.Models.MovieShowing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CinemaHallId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CinemaHallId");

                    b.HasIndex("MovieId");

                    b.ToTable("movieShowings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableSeats = 150,
                            CinemaHallId = 1,
                            MovieId = 1,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4559)
                        },
                        new
                        {
                            Id = 2,
                            AvailableSeats = 100,
                            CinemaHallId = 2,
                            MovieId = 2,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4608)
                        },
                        new
                        {
                            Id = 3,
                            AvailableSeats = 200,
                            CinemaHallId = 3,
                            MovieId = 3,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4610)
                        },
                        new
                        {
                            Id = 4,
                            AvailableSeats = 150,
                            CinemaHallId = 1,
                            MovieId = 4,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4612)
                        },
                        new
                        {
                            Id = 5,
                            AvailableSeats = 100,
                            CinemaHallId = 2,
                            MovieId = 5,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4614)
                        },
                        new
                        {
                            Id = 6,
                            AvailableSeats = 200,
                            CinemaHallId = 3,
                            MovieId = 6,
                            StartTime = new DateTime(2023, 9, 4, 21, 7, 28, 842, DateTimeKind.Local).AddTicks(4615)
                        });
                });

            modelBuilder.Entity("TicketApplication.Models.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("totalSum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("totalSum")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("shoppingCarts");
                });

            modelBuilder.Entity("TicketApplication.Models.Relationship.ShowingInOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieShowingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieShowingId");

                    b.HasIndex("OrderId");

                    b.ToTable("showingsInOrder");
                });

            modelBuilder.Entity("TicketApplication.Models.Relationship.ShowingInShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieShowingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MovieShowingId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("showingsInShoppingCart");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketApplication.Models.Models.Movie", b =>
                {
                    b.HasOne("TicketApplication.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.MovieShowing", b =>
                {
                    b.HasOne("TicketApplication.Models.Models.CinemaHall", "CinemaHall")
                        .WithMany()
                        .HasForeignKey("CinemaHallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketApplication.Models.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CinemaHall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.Order", b =>
                {
                    b.HasOne("TicketApplication.Models.Models.ApplicationUser", "applicationUser")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.ShoppingCart", b =>
                {
                    b.HasOne("TicketApplication.Models.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketApplication.Models.Relationship.ShowingInOrder", b =>
                {
                    b.HasOne("TicketApplication.Models.Models.MovieShowing", "MovieShowing")
                        .WithMany()
                        .HasForeignKey("MovieShowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketApplication.Models.Models.Order", "Order")
                        .WithMany("showingsInOrder")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieShowing");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TicketApplication.Models.Relationship.ShowingInShoppingCart", b =>
                {
                    b.HasOne("TicketApplication.Models.Models.MovieShowing", "MovieShowing")
                        .WithMany()
                        .HasForeignKey("MovieShowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketApplication.Models.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("showingsInShoppingCarts")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieShowing");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.Order", b =>
                {
                    b.Navigation("showingsInOrder");
                });

            modelBuilder.Entity("TicketApplication.Models.Models.ShoppingCart", b =>
                {
                    b.Navigation("showingsInShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}