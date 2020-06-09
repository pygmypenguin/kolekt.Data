using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kolekt.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Sequence = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(nullable: false),
                    //CreatedAt = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    AggregateType = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Sequence);
                });

            migrationBuilder.Sql("ALTER TABLE [Events] ADD [CreatedAt] as (GETUTCDATE())");
            migrationBuilder.CreateIndex(
                name: "IX_Events_Version_AggregateId",
                table: "Events",
                columns: new[] { "Version", "AggregateId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
