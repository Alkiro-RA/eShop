using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControllerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Pants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Shirts",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pants",
                columns: table => new
                {
                    PantsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    SizeWaist = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pants", x => x.PantsId);
                });

            migrationBuilder.InsertData(
                table: "Pants",
                columns: new[] { "PantsId", "Brand", "Color", "Gender", "Price", "Size", "SizeWaist", "Type" },
                values: new object[,]
                {
                    { 1, "MyBrand", "Blue", "Male", 70, 170, 100, "Jeans" },
                    { 2, "YourBrand", "Gray", "Female", 60, 160, 80, "Trousers" },
                    { 3, "TheirBrand", "Black", "Kid", 40, 110, 55, "Shorts" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pants");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Shirts",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
