using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gym_pnt1.Migrations
{
    /// <inheritdoc />
    public partial class Seagregóactividaddelcliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEntries",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEntries",
                table: "Membership");
        }
    }
}
