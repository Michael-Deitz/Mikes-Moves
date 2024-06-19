using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MikesMoves.Models;

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

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.UserProfile)
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
                PhoneNumber = "4445556666",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                UserName = "JohnDoe",
                Email = "john@doe.comx",
                PhoneNumber = "3334445555",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                UserName = "JaneSmith",
                Email = "jane@smith.comx",
                PhoneNumber = "2223334444",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                UserName = "AliceJohnson",
                Email = "alice@johnson.comx",
                PhoneNumber = "1234567890",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                UserName = "BobWilliams",
                Email = "bob@williams.comx",
                PhoneNumber = "0987654321",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                UserName = "EveDavis",
                Email = "Eve@Davis.comx",
                PhoneNumber = "1112223333",
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

            modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
            {
                new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                ImageLocation = "https://robohash.org/numquamutut.png?size=150x150&set=set1",
                DateCreated = new DateTime(2022, 1, 25),
            },
             new UserProfile
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                DateCreated = new DateTime(2023, 2, 2),
                ImageLocation = "https://robohash.org/nisiautemet.png?size=150x150&set=set1",
                IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
            },
            new UserProfile
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Smith",
                DateCreated = new DateTime(2022, 3, 15),
                ImageLocation = "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1",
                IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
            },
            new UserProfile
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                DateCreated = new DateTime(2023, 6, 10),
                ImageLocation = "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1",
                IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
            },
            new UserProfile
            {
                Id = 5,
                FirstName = "Bob",
                LastName = "Williams",
                DateCreated = new DateTime(2023, 5, 15),
                ImageLocation = "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1",
                IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
            },
            new UserProfile
            {
                Id = 6,
                FirstName = "Eve",
                LastName = "Davis",
                DateCreated = new DateTime(2022, 10, 18),
                ImageLocation = "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1",
                IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
            }
            });

            modelBuilder.Entity<Trailer>().HasData(new Trailer[]
            {
                new Trailer { Id = 1, Type = "Open", Description = "16Ft Trailer", Height = 8.0M, Width = 7.0M, Length = 16.0M, Capacity = 5000.0M, Location = "Location A", BasePrice = 250.00M, PricePerMile = 2.00M , ImageUrl = "https://www.gatormade.com/wp-content/uploads/2016/07/12-30.jpg", UserProfileId = 1 },
                new Trailer { Id = 2, Type = "Open", Description = "18Ft Trailer", Height = 9.0M, Width = 8.0M, Length = 18.0M, Capacity = 8000.0M, Location = "Location B", BasePrice = 350.00M, PricePerMile = 2.50M , ImageUrl = "https://dealer-cdn.com/IEWsDN/tbftrc/2022_PJ_Trailers_UL182-18FT_V7219_Utility_Trailer_1YPUsybgbcyq.jpg", UserProfileId = 2 },
                new Trailer { Id = 3, Type = "Open", Description = "20Ft Trailer", Height = 10.0M, Width = 8.5m, Length = 20.0M, Capacity = 10000.0M, Location = "Location C", BasePrice = 400.00M, PricePerMile = 3.00M , ImageUrl = "https://dealer-cdn.com/BRTBhm/5UPgUS/2021_PJ_Trailers_83_in._Tandem_Axle_Channel_Utility_UL_Utility_Trailer_VLqXqK.jpg", UserProfileId = 4 }
            });

            modelBuilder.Entity<Item>().HasData(new Item[]
            {
                new Item { Id = 1, TrailerId = 1, Name = "Polaris Ranger Crew", Description = "Description 1", Height = 6.3M, Width = 5.2M, Length = 12.5M, Weight = 1874.0M, ImageUrl = "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/Assets/Inventory/B9/B9/B9B9E054-562E-492F-8987-EE47D3DCB4A6.jpg", UserProfileId = 3 },
                new Item { Id = 2, TrailerId = 2, Name = "Honda Accord", Description = "Description 2", Height = 4.8M, Width = 6.1M, Length = 16.1M, Weight = 3307.0M, ImageUrl = "https://cdn.motor1.com/images/mgl/ojB1G4/0:58:1919:1438/1993-honda-accord-se-132-00-miles-pristine-condition.webp", UserProfileId = 5 },
                new Item { Id = 3, TrailerId = 3, Name = "Pair of Polaris RZR UTVs", Description = "Description 3", Height = 10.0M, Width = 8.0M, Length = 19.0M, Weight = 8000.0M, ImageUrl = "https://blog.ridenow.com/hs-fs/hubfs/2023%20Yamaha%20Wolverine%20RMAX2%20Sport%20UTVs%20in%20baby%20blue%20color%20trailing%20on%20a%20forest%20trail.jpg?width=663&height=497&name=2023%20Yamaha%20Wolverine%20RMAX2%20Sport%20UTVs%20in%20baby%20blue%20color%20trailing%20on%20a%20forest%20trail.jpg", UserProfileId = 1 }
            });

            modelBuilder.Entity<Message>().HasData(new Message[]
            {
                new Message { Id = 1, SenderId = 1, ReceiverId = 2, Content = "Message 1", DateCreated = DateTime.Now.AddDays(-1) },
                new Message { Id = 2, SenderId = 2, ReceiverId = 3, Content = "Message 2", DateCreated = DateTime.Now.AddDays(-1) },
                new Message { Id = 3, SenderId = 3, ReceiverId = 1, Content = "Message 3", DateCreated = DateTime.Now.AddDays(-1) }
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation[]
            {
                new Reservation { Id = 1, UserId = 1, TrailerId = 1, DateReserved = DateTime.Now.AddDays(-1) },
                new Reservation { Id = 2, UserId = 2, TrailerId = 2, DateReserved = DateTime.Now.AddDays(-2) },
                new Reservation { Id = 3, UserId = 3, TrailerId = 3, DateReserved = DateTime.Now.AddDays(-3) }
            });
        }
    }
}
