using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceClients.Migrations
{
    public partial class AllPaidAsEnumType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AllPaid",
                table: "Client",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "AllPaid",
                table: "Client",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
