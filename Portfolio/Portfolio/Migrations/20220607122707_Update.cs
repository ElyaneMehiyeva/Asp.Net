using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_social_about_AboutId",
                table: "social");

            migrationBuilder.DropIndex(
                name: "IX_social_AboutId",
                table: "social");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "social");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "social",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_social_AboutId",
                table: "social",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_social_about_AboutId",
                table: "social",
                column: "AboutId",
                principalTable: "about",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
