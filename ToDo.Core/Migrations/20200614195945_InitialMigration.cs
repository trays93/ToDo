using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "teszt@elek.io", "Elek", "Teszt", "titok", "tesztelek" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "john@doe.io", "John", "Doe", "secret", "johndoe" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Name", "Note", "Priority", "Status", "UserId" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new DateTime(2020, 6, 14, 21, 59, 44, 783, DateTimeKind.Local).AddTicks(2635), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Első todo", "Ez az első todo! Ez itt a todo leírása, ide jöhet minden magyarázat és jegyzet", 3, 3, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new DateTime(2020, 6, 14, 21, 59, 44, 785, DateTimeKind.Local).AddTicks(9258), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Második todo", "Ez már a második todo! Itt már más a leírás!", 1, 2, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("d173e20d-159e-4127-9ce9-b0ac2564ad97"), new DateTime(2020, 6, 14, 21, 59, 44, 785, DateTimeKind.Local).AddTicks(9309), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harmadik todo", "Ez itt a hramadik todo. Ide már nem tudok kitalálni más szöveget", 3, 3, new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") },
                    { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new DateTime(2020, 6, 14, 21, 59, 44, 785, DateTimeKind.Local).AddTicks(9319), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John's todo", "Ez itt már John todo-ja!", 1, 2, new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserId",
                table: "ToDos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
