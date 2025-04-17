using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RelationsApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedOneToOneRelationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitNumber = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "AddressId", "Email", "Name", "Phone", "Surname" },
                values: new object[,]
                {
                    { 101, 1, "dngubane@iie.ac.za", "Dumisane", 155566, "Ngubs" },
                    { 102, 2, "st2737377@vcconnect.ac.za", "Benjie", 544588, "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "Street", "StudentId", "Suburb", "UnitNumber", "Zip" },
                values: new object[,]
                {
                    { 1, "Benmore Road", 101, "Parkmore", 1, 2025 },
                    { 2, "West Street", 102, "Rivonia", 25, 2026 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
