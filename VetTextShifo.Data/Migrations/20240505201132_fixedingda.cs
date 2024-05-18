using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VetTextShifo.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedingda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerIp = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sity = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Postcode = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NewsEng",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
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
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsUzb", x => x.id);
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
                    Description = table.Column<string>(type: "text", nullable: false),
                    LikeCount = table.Column<int>(type: "integer", nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductModelName = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Customerid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_Customerid",
                        column: x => x.Customerid,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "attachmentForNews",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    NewsModelEngId = table.Column<int>(type: "integer", nullable: false),
                    NewsModelRusId = table.Column<int>(type: "integer", nullable: false),
                    NewsModelUzbId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attachmentForNews", x => x.id);
                    table.ForeignKey(
                        name: "FK_attachmentForNews_NewsEng_NewsModelEngId",
                        column: x => x.NewsModelEngId,
                        principalTable: "NewsEng",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachmentForNews_NewsRus_NewsModelRusId",
                        column: x => x.NewsModelRusId,
                        principalTable: "NewsRus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attachmentForNews_NewsUzb_NewsModelUzbId",
                        column: x => x.NewsModelUzbId,
                        principalTable: "NewsUzb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    ProductEngId = table.Column<int>(type: "integer", nullable: false),
                    ProductRusId = table.Column<int>(type: "integer", nullable: false),
                    ProductUzbId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_AttachmentProducts_ProductsEng_ProductEngId",
                        column: x => x.ProductEngId,
                        principalTable: "ProductsEng",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProducts_ProductsRus_ProductRusId",
                        column: x => x.ProductRusId,
                        principalTable: "ProductsRus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentProducts_ProductsUzb_ProductUzbId",
                        column: x => x.ProductUzbId,
                        principalTable: "ProductsUzb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    ProductModel = table.Column<string>(type: "text", nullable: false),
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
                name: "IX_Admins_email",
                table: "Admins",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachmentForNews_NewsModelEngId",
                table: "attachmentForNews",
                column: "NewsModelEngId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachmentForNews_NewsModelRusId",
                table: "attachmentForNews",
                column: "NewsModelRusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_attachmentForNews_NewsModelUzbId",
                table: "attachmentForNews",
                column: "NewsModelUzbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductEngId",
                table: "AttachmentProducts",
                column: "ProductEngId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductRusId",
                table: "AttachmentProducts",
                column: "ProductRusId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentProducts_ProductUzbId",
                table: "AttachmentProducts",
                column: "ProductUzbId");

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
                name: "IX_Customers_CustomerIp",
                table: "Customers",
                column: "CustomerIp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Customerid",
                table: "Orders",
                column: "Customerid");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "attachmentForNews");

            migrationBuilder.DropTable(
                name: "AttachmentProducts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "NewsEng");

            migrationBuilder.DropTable(
                name: "NewsRus");

            migrationBuilder.DropTable(
                name: "NewsUzb");

            migrationBuilder.DropTable(
                name: "ProductsEng");

            migrationBuilder.DropTable(
                name: "ProductsRus");

            migrationBuilder.DropTable(
                name: "ProductsUzb");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
