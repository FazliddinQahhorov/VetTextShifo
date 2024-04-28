using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForComment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "ProductModel",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductModel",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
