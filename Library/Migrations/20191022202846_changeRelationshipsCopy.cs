using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class changeRelationshipsCopy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopiesAvailable",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Copy",
                columns: table => new
                {
                    CopyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copy", x => x.CopyId);
                    table.ForeignKey(
                        name: "FK_Copy_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Copy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CopyPatron",
                columns: table => new
                {
                    CopyPatronId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CopyId = table.Column<int>(nullable: false),
                    PatronId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopyPatron", x => x.CopyPatronId);
                    table.ForeignKey(
                        name: "FK_CopyPatron_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CopyPatron_Copy_CopyId",
                        column: x => x.CopyId,
                        principalTable: "Copy",
                        principalColumn: "CopyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CopyPatron_Patron_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patron",
                        principalColumn: "PatronId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Copy_BookId",
                table: "Copy",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Copy_UserId",
                table: "Copy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CopyPatron_BookId",
                table: "CopyPatron",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CopyPatron_CopyId",
                table: "CopyPatron",
                column: "CopyId");

            migrationBuilder.CreateIndex(
                name: "IX_CopyPatron_PatronId",
                table: "CopyPatron",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "CopyPatron");

            migrationBuilder.DropTable(
                name: "Copy");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CopiesAvailable",
                table: "Books",
                nullable: false,
                defaultValue: 0);
        }
    }
}
