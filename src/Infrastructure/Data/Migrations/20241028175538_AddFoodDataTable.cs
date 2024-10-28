using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstaKcalWebApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Images",
                type: "datetime2",
                nullable: true);
        }
    }
}
