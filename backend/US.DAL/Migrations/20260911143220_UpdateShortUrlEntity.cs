using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace US.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShortUrlEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "ShortUrls",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_ShortCode",
                table: "ShortUrls",
                column: "ShortCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_ShortCode",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "ShortCode",
                table: "ShortUrls");
        }
    }
}
