using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MikesMoves.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace MikesMoves.Data
{
    public class MikesMovesDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public MikesMovesDbContext(DbContextOptions<MikesMovesDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>().HasKey(r => new { r.UserId, r.TrailerId });

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Trailer)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TrailerId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
            {
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    UserName = "JohnDoe",
                    Email = "john@doe.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    UserName = "JaneSmith",
                    Email = "jane@smith.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    UserName = "AliceJohnson",
                    Email = "alice@johnson.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    UserName = "BobWilliams",
                    Email = "bob@williams.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
                new IdentityUser
                {
                    Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    UserName = "EveDavis",
                    Email = "Eve@Davis.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
                },
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                },
            });

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2022, 1, 25)
                },
                new User
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2023, 2, 2),
                    IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2022, 3, 15),
                    IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3"
                },
                new User
                {
                    Id = 4,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2023, 6, 10),
                    IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b"
                },
                new User
                {
                    Id = 5,
                    FirstName = "Bob",
                    LastName = "Williams",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2023, 5, 15),
                    IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2"
                },
                new User
                {
                    Id = 6,
                    FirstName = "Eve",
                    LastName = "Davis",
                    PhoneNumber = "123-456-7890",
                    DateCreated = new DateTime(2022, 10, 18),
                    IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d"
                }
            });

            modelBuilder.Entity<Trailer>().HasData(new Trailer[]
            {
                new Trailer { Id = 1, Height = 10, Width = 5, Length = 20, Capacity = 1000, Location = "Location A", BasePrice = 50 },
                new Trailer { Id = 2, Height = 12, Width = 6, Length = 25, Capacity = 1200, Location = "Location B", BasePrice = 60 },
                new Trailer { Id = 3, Height = 8, Width = 4, Length = 15, Capacity = 800, Location = "Location C", BasePrice = 40 }
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item { Id = 1, TrailerId = 1, Name = "Item 1", Description = "Description 1" },
                new Item { Id = 2, TrailerId = 2, Name = "Item 2", Description = "Description 2" },
                new Item { Id = 3, TrailerId = 3, Name = "Item 3", Description = "Description 3" }
            });

            modelBuilder.Entity<Message>().HasData(new Message[]
            {
                new Message { Id = 1, SenderId = 1, ReceiverId = 2, Content = "Message 1", DateCreated = DateTime.Now.AddDays(-1) },
                new Message { Id = 2, SenderId = 2, ReceiverId = 3, Content = "Message 2", DateCreated = DateTime.Now.AddDays(-1) },
                new Message { Id = 3, SenderId = 3, ReceiverId = 1, Content = "Message 3", DateCreated = DateTime.Now.AddDays(-1) }
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation[]
            {
                new Reservation { UserId = 1, TrailerId = 1, DateReserved = DateTime.Now.AddDays(-1) },
                new Reservation { UserId = 2, TrailerId = 2, DateReserved = DateTime.Now.AddDays(-2) },
                new Reservation { UserId = 3, TrailerId = 3, DateReserved = DateTime.Now.AddDays(-3) }
            });
        }
    }
}
