using Microsoft.EntityFrameworkCore.Migrations;
using Testing_general.Models;

#nullable disable

namespace Testing_general.Migrations
{
    /// <inheritdoc />
    public partial class Tambahdeskripsiitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
