using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    /// <inheritdoc />
    public partial class engOhirgisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ProductsUzb",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ProductsRus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "ProductsEng",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductsUzb");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductsRus");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductsEng");
        }
    }
}
