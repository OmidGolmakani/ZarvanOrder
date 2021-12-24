using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZarvanOrder.Migrations
{
    public partial class AddGoodsGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodsGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherId = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsGroup_GoodsGroup_FatherId",
                        column: x => x.FatherId,
                        principalTable: "GoodsGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsGroup_FatherId",
                table: "GoodsGroup",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsGroup_RefId_Code_Name",
                table: "GoodsGroup",
                columns: new[] { "RefId", "Code", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsGroup");
        }
    }
}
