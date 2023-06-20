using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb4_MVC_Razor.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "BookLists",
                columns: table => new
                {
                    BookListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_BookId = table.Column<int>(type: "int", nullable: false),
                    FK_CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLists", x => x.BookListId);
                    table.ForeignKey(
                        name: "FK_BookLists_Books_FK_BookId",
                        column: x => x.FK_BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLists_Customers_FK_CustomerId",
                        column: x => x.FK_CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Miguel Cervantes", "The journey of a madman", "Don Quijote" },
                    { 2, "Daniel Defoe", "The tale of a shipwrecked man", "Robinson Crusoe" },
                    { 3, "J.K Rowling", "The tale of young wizard", "Harry Potter" },
                    { 4, "J.R.R Tolkien", "Charachters come together to fight evil", "The Lord of the Rings" },
                    { 5, "Leo Tolstoy", "We follow aristocratic families in Russia during the Napoleonic wars", "War and Peace" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { 1, "Kyrklägdan 18", "jon@mail.com", "Jon", "Westman", "0701234567" },
                    { 2, "Kyrklägdan 18", "malin@mail.com", "Malin", "Eriksson", "0701234568" },
                    { 3, "Svenssonvägen 1", "sven@mail.com", "Sven", "Svensson", "0701234569" },
                    { 4, "Perssongatan 1", "ake@mail.com", "Åke", "Persson", "0701234560" },
                    { 5, "Kyrkogatan 1", "lisa@mail.com", "Lisa", "Nilsson", "0701234561" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLists_FK_BookId",
                table: "BookLists",
                column: "FK_BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLists_FK_CustomerId",
                table: "BookLists",
                column: "FK_CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLists");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
