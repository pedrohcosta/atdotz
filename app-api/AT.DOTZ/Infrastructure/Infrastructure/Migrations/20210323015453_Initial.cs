using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(150)", nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Dotz = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(type: "varchar(20)", nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCard_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountExtract",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DocumentCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Observation = table.Column<string>(type: "varchar(100)", nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    Dotz = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountExtract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountExtract_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Active", "Balance", "Data", "Dotz", "Mail", "Name", "Number" },
                values: new object[] { new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), true, 10000m, new DateTime(2021, 3, 22, 22, 54, 52, 709, DateTimeKind.Local).AddTicks(4920), 1000, "ordep@hotmail.com", "Ordep", "1679951256" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Active", "Balance", "Data", "Dotz", "Mail", "Name", "Number" },
                values: new object[] { new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f20"), true, 20000m, new DateTime(2021, 3, 22, 22, 54, 52, 713, DateTimeKind.Local).AddTicks(427), 2000, "Atram@hotmail.com", "Atram", "902183848" });

            migrationBuilder.InsertData(
                table: "AccountCard",
                columns: new[] { "Id", "AccountId", "Active", "Data", "Number", "Type" },
                values: new object[,]
                {
                    { new Guid("31e74709-ab02-424c-a189-10521e936de3"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), true, new DateTime(2021, 3, 22, 22, 54, 52, 715, DateTimeKind.Local).AddTicks(9483), "5555-6666-7777-8888", 1 },
                    { new Guid("fcea9cec-489b-46cd-94ad-c8050c993872"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), true, new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3332), "6666-7777-8888-5555", 2 },
                    { new Guid("a0a1478f-0931-4c03-a210-1ac9c1680df9"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), true, new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3472), "7777-8888-5555-6666", 2 },
                    { new Guid("467acd0b-23d7-421d-9d18-a81aa856b77b"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f20"), true, new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(3485), "1111-2222-3333-4444", 1 }
                });

            migrationBuilder.InsertData(
                table: "AccountExtract",
                columns: new[] { "Id", "AccountId", "Amount", "Data", "DocumentCode", "Dotz", "Observation", "Peso", "Type" },
                values: new object[,]
                {
                    { new Guid("08f988e7-e0c3-46d5-8b84-5f1329b5bf77"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), 1000m, new DateTime(2021, 3, 22, 22, 54, 52, 716, DateTimeKind.Local).AddTicks(5494), "123456789", 100, "", 10, 1 },
                    { new Guid("330952e4-bfd2-476b-8621-a5a435cfc14b"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), 2000m, new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(2990), "234567891", 200, "Depositao A", 10, 1 },
                    { new Guid("02fcb756-3413-4f28-b863-6d5de9231117"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), 1500m, new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(3182), "345678912", 150, "Deposito B", 10, 1 },
                    { new Guid("cb0ffde5-4bcd-4509-95e7-ff002407f678"), new Guid("ddc9ccde-fc66-4d07-820c-5f7601756f10"), 100m, new DateTime(2021, 3, 22, 22, 54, 52, 717, DateTimeKind.Local).AddTicks(3197), "987654321", 10, "Pagamento B", 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCard_AccountId",
                table: "AccountCard",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountExtract_AccountId",
                table: "AccountExtract",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCard");

            migrationBuilder.DropTable(
                name: "AccountExtract");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
