using Microsoft.EntityFrameworkCore.Migrations;

namespace PRS_Server.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNbr = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Unit = table.Column<string>(maxLength: 15, nullable: false),
                    PhotoPath = table.Column<string>(maxLength: 255, nullable: true),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requestlines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requestlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 80, nullable: false),
                    Justification = table.Column<string>(maxLength: 80, nullable: false),
                    RejectionReason = table.Column<string>(maxLength: 80, nullable: true),
                    DeliveryMode = table.Column<string>(maxLength: 30, nullable: false),
                    Status = table.Column<string>(maxLength: 30, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    Firstname = table.Column<string>(maxLength: 30, nullable: false),
                    Lastname = table.Column<string>(maxLength: 30, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    isReviewer = table.Column<bool>(nullable: false),
                    isAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    Zip = table.Column<string>(maxLength: 5, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PartNbr",
                table: "Products",
                column: "PartNbr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Code",
                table: "Vendors",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Requestlines");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
