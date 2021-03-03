using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Naming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "FrameMaterial");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "OrderEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderEntityId");

            migrationBuilder.CreateTable(
                name: "FrameEntityMaterialEntity",
                columns: table => new
                {
                    FramesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameEntityMaterialEntity", x => new { x.FramesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_FrameEntityMaterialEntity_Frames_FramesId",
                        column: x => x.FramesId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameEntityMaterialEntity_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrameEntityMaterialEntity_MaterialsId",
                table: "FrameEntityMaterialEntity",
                column: "MaterialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderEntityId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "FrameEntityMaterialEntity");

            migrationBuilder.RenameColumn(
                name: "OrderEntityId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderEntityId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.CreateTable(
                name: "FrameMaterial",
                columns: table => new
                {
                    FramesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameMaterial", x => new { x.FramesId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_FrameMaterial_Frames_FramesId",
                        column: x => x.FramesId,
                        principalTable: "Frames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrameMaterial_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FrameMaterial_MaterialsId",
                table: "FrameMaterial",
                column: "MaterialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
