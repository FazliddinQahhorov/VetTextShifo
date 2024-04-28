using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Comments",
                newName: "comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comments",
                newName: "Comment");
        }
    }
}
