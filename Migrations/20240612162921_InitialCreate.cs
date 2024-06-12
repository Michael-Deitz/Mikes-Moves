using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MikesMoves.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    Width = table.Column<decimal>(type: "numeric", nullable: false),
                    Length = table.Column<decimal>(type: "numeric", nullable: false),
                    Capacity = table.Column<decimal>(type: "numeric", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PricePerMile = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageLocation = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IdentityUserId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ImageBlob = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrailerId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Height = table.Column<decimal>(type: "numeric", nullable: false),
                    Width = table.Column<decimal>(type: "numeric", nullable: false),
                    Length = table.Column<decimal>(type: "numeric", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_UserProfiles_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_UserProfiles_SenderId",
                        column: x => x.SenderId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TrailerId = table.Column<int>(type: "integer", nullable: false),
                    DateReserved = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.UserId, x.TrailerId });
                    table.ForeignKey(
                        name: "FK_Reservations_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", 0, "bec59980-8df6-4cbd-b6d5-758b1ba938f5", "bob@williams.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAENVzAPr7NIXqANg3UO/0yTGKBNHnM617IS7BgIu/6e3FaszPwf2zltxeJLAIJybJoQ==", "0987654321", false, "fd5d9068-1cef-44f1-a365-ec05db86e651", false, "BobWilliams" },
                    { "a7d21fac-3b21-454a-a747-075f072d0cf3", 0, "cf289da4-f2a2-4481-8708-d21aa5ab9f56", "jane@smith.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEOxkvrysmZBkGYrrc1tLcRkAVLffK2mBZoDtuC0Rjhmi4mAAEkqny0lT3ME6EUJEQQ==", "2223334444", false, "9971a2d2-54fd-46d5-a86a-78c5de27618c", false, "JaneSmith" },
                    { "c806cfae-bda9-47c5-8473-dd52fd056a9b", 0, "1a933ca6-c73c-4704-8f8f-c59882a9aba7", "alice@johnson.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEBvbmzN2HaN9BYYiBI8Ii3jNaeUIvZPXzfztGoVscM2icKwayDZbT1GWCp7nbAyIHQ==", "1234567890", false, "cbb18a54-3ac1-45b4-a3cb-068055ced065", false, "AliceJohnson" },
                    { "d224a03d-bf0c-4a05-b728-e3521e45d74d", 0, "32053d6e-1240-47ab-8c43-3a6c74ae1de6", "Eve@Davis.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAELxasz6Nom03B+CMZrAN7u0BZElYJoIgD5diduu3Y8wHq0xTSVCntDFWjHvzy68APw==", "1112223333", false, "805f7eb9-560c-4e24-91aa-f9ddb8f24734", false, "EveDavis" },
                    { "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", 0, "e94cde1f-469d-4db6-901f-25669948f184", "john@doe.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEHgmwiT/lDCKlNI1zF04qPEq6xFkfMvxxWF212Lf8I1D8dm5mzMM2Z0rWZEWke7HVA==", "3334445555", false, "a804d56d-48dc-4e4f-8989-3c499e08da3d", false, "JohnDoe" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "64f18a62-f0dd-494d-ad22-0ec518d2c044", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEN5yCBuIum5jh7N1dUX1cFPQNNHB6UvDg4yMCmb6jfuZTvfX2KeG5hAcMo/lwIHUTw==", "4445556666", false, "7af42361-a05b-4a7a-8a43-0cdd69fd7210", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Trailers",
                columns: new[] { "Id", "BasePrice", "Capacity", "Description", "Height", "ImageUrl", "Length", "Location", "PricePerMile", "Type", "UserProfileId", "Width" },
                values: new object[,]
                {
                    { 1, 250.00m, 5000.0m, "16Ft Trailer", 8.0m, "https://www.gatormade.com/wp-content/uploads/2016/07/12-30.jpg", 16.0m, "Location A", 2.00m, "Open", 1, 7.0m },
                    { 2, 350.00m, 8000.0m, "18Ft Trailer", 9.0m, "https://dealer-cdn.com/IEWsDN/tbftrc/2022_PJ_Trailers_UL182-18FT_V7219_Utility_Trailer_1YPUsybgbcyq.jpg", 18.0m, "Location B", 2.50m, "Open", 2, 8.0m },
                    { 3, 400.00m, 10000.0m, "20Ft Trailer", 10.0m, "https://dealer-cdn.com/BRTBhm/5UPgUS/2021_PJ_Trailers_83_in._Tandem_Axle_Channel_Utility_UL_Utility_Trailer_VLqXqK.jpg", 20.0m, "Location C", 3.00m, "Open", 4, 8.5m }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Height", "ImageUrl", "Length", "Name", "TrailerId", "UserProfileId", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, "Description 1", 6.3m, "https://cdn.dealerspike.com/imglib/v1/800x600/imglib/Assets/Inventory/B9/B9/B9B9E054-562E-492F-8987-EE47D3DCB4A6.jpg", 12.5m, "Polaris Ranger Crew", 1, 3, 1874.0m, 5.2m },
                    { 2, "Description 2", 4.8m, "https://cdn.motor1.com/images/mgl/ojB1G4/0:58:1919:1438/1993-honda-accord-se-132-00-miles-pristine-condition.webp", 16.1m, "Honda Accord", 2, 5, 3307.0m, 6.1m },
                    { 3, "Description 3", 10.0m, "https://blog.ridenow.com/hs-fs/hubfs/2023%20Yamaha%20Wolverine%20RMAX2%20Sport%20UTVs%20in%20baby%20blue%20color%20trailing%20on%20a%20forest%20trail.jpg?width=663&height=497&name=2023%20Yamaha%20Wolverine%20RMAX2%20Sport%20UTVs%20in%20baby%20blue%20color%20trailing%20on%20a%20forest%20trail.jpg", 19.0m, "Pair of Polaris RZR UTVs", 3, 1, 8000.0m, 8.0m }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "DateCreated", "FirstName", "IdentityUserId", "ImageBlob", "ImageLocation", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", null, "https://robohash.org/numquamutut.png?size=150x150&set=set1", "Strator" },
                    { 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "d8d76512-74f1-43bb-b1fd-87d3a8aa36df", null, "https://robohash.org/nisiautemet.png?size=150x150&set=set1", "Doe" },
                    { 3, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "a7d21fac-3b21-454a-a747-075f072d0cf3", null, "https://robohash.org/molestiaemagnamet.png?size=150x150&set=set1", "Smith" },
                    { 4, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "c806cfae-bda9-47c5-8473-dd52fd056a9b", null, "https://robohash.org/deseruntutipsum.png?size=150x150&set=set1", "Johnson" },
                    { 5, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "9ce89d88-75da-4a80-9b0d-3fe58582b8e2", null, "https://robohash.org/quiundedignissimos.png?size=150x150&set=set1", "Williams" },
                    { 6, new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eve", "d224a03d-bf0c-4a05-b728-e3521e45d74d", null, "https://robohash.org/hicnihilipsa.png?size=150x150&set=set1", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "DateCreated", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, "Message 1", new DateTime(2024, 6, 11, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4567), 2, 1 },
                    { 2, "Message 2", new DateTime(2024, 6, 11, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4656), 3, 2 },
                    { 3, "Message 3", new DateTime(2024, 6, 11, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4659), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "TrailerId", "UserId", "DateReserved" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 11, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4705) },
                    { 2, 2, new DateTime(2024, 6, 10, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4709) },
                    { 3, 3, new DateTime(2024, 6, 9, 11, 29, 20, 595, DateTimeKind.Local).AddTicks(4716) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_TrailerId",
                table: "Items",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TrailerId",
                table: "Reservations",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
