using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarServiceClients.Migrations
{
    public partial class NewTablesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Car",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Service",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Service",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Service",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsPaid",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditDate",
                table: "Service",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Service",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceID");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Adress = table.Column<string>(maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(maxLength: 6, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Mail = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    NIP = table.Column<string>(maxLength: 50, nullable: true),
                    AllPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Adress = table.Column<string>(maxLength: 50, nullable: false),
                    PostCode = table.Column<string>(maxLength: 6, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Mail = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Profession = table.Column<int>(maxLength: 50, nullable: false),
                    IsFree = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfProducion = table.Column<DateTime>(nullable: false),
                    BodyType = table.Column<int>(maxLength: 50, nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: true),
                    EngineCapacity = table.Column<float>(nullable: false),
                    EngineType = table.Column<string>(maxLength: 50, nullable: true),
                    FuelType = table.Column<int>(maxLength: 50, nullable: false),
                    PlateNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Vin = table.Column<string>(maxLength: 50, nullable: false),
                    ClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_ClientID",
                table: "Service",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_EmployeeID",
                table: "Service",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ClientID",
                table: "Car",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Client_ClientID",
                table: "Service",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Employee_EmployeeID",
                table: "Service",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Client_ClientID",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Employee_EmployeeID",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ClientID",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_EmployeeID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "LastEditDate",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Car",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");
        }
    }
}
