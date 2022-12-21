using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class FluentAPIModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fluent_PublisherPublisher_Id",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fluent_AuthorAuthor_Id",
                table: "BookAuthors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fluent_BookBook_Id",
                table: "BookAuthors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fluent_Authors",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Authors", x => x.Author_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Books",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false),
                    Publisher_Id = table.Column<int>(type: "int", nullable: false),
                    Publisher_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Books", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Fluent_Books_BookDetails_BookDetail_Id",
                        column: x => x.BookDetail_Id,
                        principalTable: "BookDetails",
                        principalColumn: "BookDetail_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_Books_Publishers_Publisher_Id1",
                        column: x => x.Publisher_Id1,
                        principalTable: "Publishers",
                        principalColumn: "Publisher_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_Publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publishers", x => x.Publisher_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Fluent_PublisherPublisher_Id",
                table: "Books",
                column: "Fluent_PublisherPublisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Fluent_AuthorAuthor_Id",
                table: "BookAuthors",
                column: "Fluent_AuthorAuthor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Fluent_BookBook_Id",
                table: "BookAuthors",
                column: "Fluent_BookBook_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_BookDetail_Id",
                table: "Fluent_Books",
                column: "BookDetail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_Publisher_Id1",
                table: "Fluent_Books",
                column: "Publisher_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Fluent_Authors_Fluent_AuthorAuthor_Id",
                table: "BookAuthors",
                column: "Fluent_AuthorAuthor_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Fluent_Books_Fluent_BookBook_Id",
                table: "BookAuthors",
                column: "Fluent_BookBook_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Fluent_Publishers_Fluent_PublisherPublisher_Id",
                table: "Books",
                column: "Fluent_PublisherPublisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Fluent_Authors_Fluent_AuthorAuthor_Id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Fluent_Books_Fluent_BookBook_Id",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Fluent_Publishers_Fluent_PublisherPublisher_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Fluent_Authors");

            migrationBuilder.DropTable(
                name: "Fluent_Books");

            migrationBuilder.DropTable(
                name: "Fluent_Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Books_Fluent_PublisherPublisher_Id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_Fluent_AuthorAuthor_Id",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_Fluent_BookBook_Id",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "Fluent_PublisherPublisher_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Fluent_AuthorAuthor_Id",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "Fluent_BookBook_Id",
                table: "BookAuthors");
        }
    }
}
