using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MikesMoves.Migrations
{
    /// <inheritdoc />
    public partial class EnsureImageBlobColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBlob",
                table: "UserProfiles",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89cc1528-6b7f-4c0c-8c52-bbe205c733bf", "AQAAAAIAAYagAAAAEE5wK8ErN6q9Z1FkD3nAujODOHjSmAs4Dzp39HaHghyMsgh1ksFifOQjhFt7R7UILw==", "dc03299d-1f9b-44df-80ae-553907aff50c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba85bb35-19db-44a1-8701-595858c021ed", "AQAAAAIAAYagAAAAEBjfjxZrvlml4sKbmjBc9m0bIPrAyc1KrDBgq+fjN2vwYxBiBJ2du+IVPUTqfgpeHw==", "ff27029d-d85f-408c-a3a9-e28f015ef87f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0d7443a-26a0-41f4-8f43-449f0a7c427a", "AQAAAAIAAYagAAAAEMdtB8KHZlLPQLwc4lXKtg0UmGJnocRZ0jRECMorA2uoBoAE55vVyBDwejiW92XyZg==", "3ac8df9d-bb6e-42a8-9568-8372977a2053" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c87867a-6221-4e29-a539-612b13ee7952", "AQAAAAIAAYagAAAAEF0x6hgkUhpbasGwXTS0u1bv7bNeiT39Bri9y02BqC4qmFNle68fWwC24HVrT09Xkg==", "977d0607-ec7f-4c8d-85c7-2892c052bdf5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b401712-0609-40c3-91e9-28362a5ba2e8", "AQAAAAIAAYagAAAAEARRwPbWTmmE5swhcOATubo2dX56WIF6pr3mwNgj5MQoBBorIR0xeeuVP3kri0EJ8g==", "95611dcc-2d8e-4c42-8bcc-96a51e0cd902" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01560c42-d8e0-4075-8b46-e3bbbfff3cb7", "AQAAAAIAAYagAAAAEJr6i3bGqNDQbFonVo69SDx74rhCCx0sagG1vgy3TyQpyy8qABS9BvJZH1fafrTQGQ==", "95806742-4e8e-48f6-973e-d1a4f4536bae" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 6, 10, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1317));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 6, 10, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 6, 10, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1429));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 10, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 9, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 8, 12, 3, 22, 501, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageBlob",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageBlob",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageBlob",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageBlob",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageBlob",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageBlob",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBlob",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "544d2a5c-7184-4407-9799-664dd21e1058", "AQAAAAIAAYagAAAAEFpgjxVqnPvbnviEfGwNN+u0lbIW0/VM03U3yEwTTWDbbj5FZ7Mcragn9ITn06pZPA==", "d40d3945-ef32-465e-b60e-89bee8876e41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7d21fac-3b21-454a-a747-075f072d0cf3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96350012-2201-46ea-afd0-fc3826a79e96", "AQAAAAIAAYagAAAAEC2gG2clScLGN/9pmb8e45KoU5wUXLJr/qWCt13qM/lI4c6CiRJ9TQtbQh7MH6zMuA==", "ca7ada6e-42a7-42da-93ff-c11938f57d2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24656b9f-717d-4c96-a2ae-8f31f3c16b42", "AQAAAAIAAYagAAAAEMbBqCCxaX2md6KW1EoWlX59k7TLGS8J1+HTq5cizcgfTzEwwzfDRA3yBDmqow7rvQ==", "6ee34d56-733d-45f0-a464-ddeb5850b9b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "748dffdc-e12b-4e26-9117-13445c29a7b3", "AQAAAAIAAYagAAAAENalcnLn4zVf5WESW/yppsHOenj/MUJFsEoZ0a1waIELO+IFIvQQ0w/2D+eQqL9yfw==", "db6802eb-7e3a-43b6-a671-682be28b2d10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62859190-7895-48bc-92d6-b375da3e8add", "AQAAAAIAAYagAAAAEB4nsgabgXAvLW8P+uJDlyVePvwdgbr9OKjq6UG/RAlR05RTghKTaoINl3AMkp18/A==", "2c28ec08-9646-48b4-9315-c5cf5e3f2dcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa479e87-355c-48b1-ba4f-4cff602be95e", "AQAAAAIAAYagAAAAEMiNfCr+HDLiA4eNJTwR3GUprSptm5+/052Jau48AJrzp7LAB3B7D1sOvk6iGTiYqw==", "5113d1c1-c38c-49ab-9fa8-2dcdac405d63" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 6, 9, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 6, 9, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 6, 9, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 9, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 8, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1542));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumns: new[] { "TrailerId", "UserId" },
                keyValues: new object[] { 3, 3 },
                column: "DateReserved",
                value: new DateTime(2024, 6, 7, 15, 29, 48, 744, DateTimeKind.Local).AddTicks(1550));
        }
    }
}
