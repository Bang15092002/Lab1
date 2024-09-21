using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObjects.Migrations
{
    /// <inheritdoc />
    public partial class initialCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Birthday", "Fullname", "Gender", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "123 Elm Street", new DateOnly(1990, 1, 1), "John Doe", "Male", "Password123", "johnDoe" },
                    { 2, "456 Oak Avenue", new DateOnly(1992, 2, 15), "Jane Doe", "Female", "Password456", "janeDoe" },
                    { 3, "123 Elm Street", new DateOnly(1990, 1, 1), "John Doe", "Male", "Password123", "johnDoe" },
                    { 4, "123 Elm Street", new DateOnly(1990, 1, 1), "John Doe", "Male", "Password123", "johnDoe" },
                    { 5, "123 Elm Street", new DateOnly(1990, 1, 1), "John Doe", "Male", "Password123", "johnDoe" },
                    { 6, "123 Elm Street", new DateOnly(1990, 1, 1), "John Doe", "Male", "Password123", "johnDoe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
