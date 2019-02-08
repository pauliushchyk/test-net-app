using Microsoft.EntityFrameworkCore.Migrations;

namespace testnetapp.Data.Migrations
{
    public partial class ChangedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Books_TagId",
                table: "BookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tags_TagId1",
                table: "BookTag");

            migrationBuilder.DropIndex(
                name: "IX_BookTag_TagId1",
                table: "BookTag");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "BookTag");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tags_TagId",
                table: "BookTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Tags_TagId",
                table: "BookTag");

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "BookTag",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookTag_TagId1",
                table: "BookTag",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Books_TagId",
                table: "BookTag",
                column: "TagId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Tags_TagId1",
                table: "BookTag",
                column: "TagId1",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
