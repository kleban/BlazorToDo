using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.ServerSide.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { new Guid("8be18ed7-a0f2-4f83-9ebb-5cabe34b3cf2"), "ivan@oa.edu.ua", "Ivan" },
                    { new Guid("c550f404-8615-4c95-97cb-283ea3a64fcd"), "andriy@oa.edu.ua", "Andriy" }
                });

            migrationBuilder.InsertData(
                table: "ToDoItems",
                columns: new[] { "Id", "CreatedOn", "DueDate", "IsComplete", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("a619c39a-71d1-489a-a9a5-31bba3ec660a"), new DateTime(2023, 12, 6, 10, 59, 31, 204, DateTimeKind.Local).AddTicks(4201), new DateTime(2023, 12, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), false, "Видати лаб. 3 для КН-3", new Guid("c550f404-8615-4c95-97cb-283ea3a64fcd") },
                    { new Guid("c2089682-81bd-4320-ae1b-66d0fae30ab4"), new DateTime(2023, 12, 6, 10, 59, 31, 204, DateTimeKind.Local).AddTicks(4285), new DateTime(2023, 12, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), false, "Перечитати курсові КН-4", new Guid("8be18ed7-a0f2-4f83-9ebb-5cabe34b3cf2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_UserId",
                table: "ToDoItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
