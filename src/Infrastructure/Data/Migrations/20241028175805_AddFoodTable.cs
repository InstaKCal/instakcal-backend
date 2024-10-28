using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaKcalWebApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Proteins = table.Column<float>(type: "real", nullable: true),
                    Carbohydrates = table.Column<float>(type: "real", nullable: true),
                    Sugars = table.Column<float>(type: "real", nullable: true),
                    Fiber = table.Column<float>(type: "real", nullable: true),
                    Fats = table.Column<float>(type: "real", nullable: true),
                    SaturateFats = table.Column<float>(type: "real", nullable: true),
                    TransFats = table.Column<float>(type: "real", nullable: true),
                    UnsaturateFats = table.Column<float>(type: "real", nullable: true),
                    Sodium = table.Column<float>(type: "real", nullable: true),
                    Cholesterol = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodData");
        }
    }
}
