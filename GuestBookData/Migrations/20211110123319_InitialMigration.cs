using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestbookData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestbookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestbookEntries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GuestbookEntries",
                columns: new[] { "Id", "Comment", "Email", "Name", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Awesome site bro, but I don't like the background that much.", "adam@gmail.com", "Adam", new DateTime(2021, 11, 9, 23, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Umm... where do I submit the post?", "bernard@yahoo.com", "Bernard", new DateTime(2021, 11, 9, 22, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "We work so hard to deliver all these awesome software and people use it to make stuff like this -_-", "cecilia@microsoft.com", "Cecilia", new DateTime(2021, 11, 9, 21, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "I was here and found your interface inadequate.", "dick@gmail.com", "Dick", new DateTime(2021, 11, 9, 20, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Lovely site, keep it going!", "ernest@aol.com", "Ernest", new DateTime(2021, 11, 9, 19, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ ಠ_ಠ", "filip@gmail.com", "Filip", new DateTime(2021, 11, 9, 21, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestbookEntries");
        }
    }
}
