using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentProducts_Products_ProductId",
                table: "AttachmentProducts");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentProducts_ProductId",
                table: "AttachmentProducts");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "CatigoryName",
                table: "Catigories",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductEngid",
                table: "AttachmentProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductRusid",
                table: "AttachmentProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductUzbid",
                table: "AttachmentProducts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerIP = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Customerid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Likes_Customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NewsEng",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsEng", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NewsRus",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsRus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NewsUzb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsUzb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsEng",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    GuaranteePeriod = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<bool>(type: "boolean", nullable: false),
                    MadeIn = table.Column<string>(type: "text", nullable: false),
                    Produced = table.Column<string>(type: "text", nullable: false),
                    ExtraDevices = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    PaymentContract = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsEng", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsRus",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    GuaranteePeriod = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<bool>(type: "boolean", nullable: false),
                    MadeIn = table.Column<string>(type: "text", nullable: false),
                    Produced = table.Column<string>(type: "text", nullable: false),
                    ExtraDevices = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    PaymentContract = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LikeCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsRus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsUzb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    GuaranteePeriod = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<bool>(type: "boolean", nullable: false),
                    MadeIn = table.Column<string>(type: "text", nullable: false),
                    Produced = table.Column<string>(type: "text", nullable: false),
                    ExtraDevices = table.Column<string>(type: "text", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    PaymentContract = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LikeCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsUzb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductEngid = table.Column<int>(type: "integer", nullable: true),
                    ProductRusid = table.Column<int>(type: "integer", nullable: true),
                    ProductUzbid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_ProductsEng_ProductEngid",
                        column: x => x.ProductEngid,
                        principalTable: "ProductsEng",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comments_ProductsRus_ProductRusid",
                        column: x => x.ProductRusid,
                        principalTable: "ProductsRus",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comments_ProductsUzb_ProductUzbid",
                        column: x => x.ProductUzbid,
                        principalTable: "ProductsUzb",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductEngid",
                table: "AttachmentProducts",
                column: "ProductEngid");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductRusid",
                table: "AttachmentProducts",
                column: "ProductRusid");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductUzbid",
                table: "AttachmentProducts",
                column: "ProductUzbid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductEngid",
                table: "Comments",
                column: "ProductEngid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductRusid",
                table: "Comments",
                column: "ProductRusid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductUzbid",
                table: "Comments",
                column: "ProductUzbid");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_Customerid",
                table: "Likes",
                column: "Customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsEng_ModelName",
                table: "ProductsEng",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsRus_ModelName",
                table: "ProductsRus",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsUzb_ModelName",
                table: "ProductsUzb",
                column: "ModelName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentProducts_ProductsEng_ProductEngid",
                table: "AttachmentProducts",
                column: "ProductEngid",
                principalTable: "ProductsEng",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentProducts_ProductsRus_ProductRusid",
                table: "AttachmentProducts",
                column: "ProductRusid",
                principalTable: "ProductsRus",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentProducts_ProductsUzb_ProductUzbid",
                table: "AttachmentProducts",
                column: "ProductUzbid",
                principalTable: "ProductsUzb",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentProducts_ProductsEng_ProductEngid",
                table: "AttachmentProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentProducts_ProductsRus_ProductRusid",
                table: "AttachmentProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_AttachmentProducts_ProductsUzb_ProductUzbid",
                table: "AttachmentProducts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "NewsEng");

            migrationBuilder.DropTable(
                name: "NewsRus");

            migrationBuilder.DropTable(
                name: "NewsUzb");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductsEng");

            migrationBuilder.DropTable(
                name: "ProductsRus");

            migrationBuilder.DropTable(
                name: "ProductsUzb");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentProducts_ProductEngid",
                table: "AttachmentProducts");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentProducts_ProductRusid",
                table: "AttachmentProducts");

            migrationBuilder.DropIndex(
                name: "IX_AttachmentProducts_ProductUzbid",
                table: "AttachmentProducts");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ProductEngid",
                table: "AttachmentProducts");

            migrationBuilder.DropColumn(
                name: "ProductRusid",
                table: "AttachmentProducts");

            migrationBuilder.DropColumn(
                name: "ProductUzbid",
                table: "AttachmentProducts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Catigories",
                newName: "CatigoryName");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "Locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttachmentId = table.Column<int>(type: "integer", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ExtraDevices = table.Column<string>(type: "text", nullable: false),
                    GuaranteePeriod = table.Column<string>(type: "text", nullable: false),
                    MadeIn = table.Column<string>(type: "text", nullable: false),
                    ModelName = table.Column<string>(type: "text", nullable: false),
                    PaymentContract = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentType = table.Column<string>(type: "text", nullable: false),
                    Produced = table.Column<string>(type: "text", nullable: false),
                    Service = table.Column<bool>(type: "boolean", nullable: false),
                    languageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductId",
                table: "AttachmentProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttachmentProducts_Products_ProductId",
                table: "AttachmentProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
