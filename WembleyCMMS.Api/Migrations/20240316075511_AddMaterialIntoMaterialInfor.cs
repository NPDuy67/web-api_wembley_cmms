using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialIntoMaterialInfor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialHistoryCard_MaterialInfors_MaterialInforId",
                table: "MaterialHistoryCard");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialInforId",
                table: "MaterialHistoryCard",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    MaintenanceResponseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                        column: x => x.MaintenanceResponseId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialId",
                table: "Material",
                column: "MaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialInforId",
                table: "Material",
                column: "MaterialInforId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialHistoryCard_MaterialInfors_MaterialInforId",
                table: "MaterialHistoryCard",
                column: "MaterialInforId",
                principalTable: "MaterialInfors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialHistoryCard_MaterialInfors_MaterialInforId",
                table: "MaterialHistoryCard");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialInforId",
                table: "MaterialHistoryCard",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceResponseId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaintenanceResponses_MaintenanceResponseId",
                        column: x => x.MaintenanceResponseId,
                        principalTable: "MaintenanceResponses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaintenanceResponseId",
                table: "Materials",
                column: "MaintenanceResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialId",
                table: "Materials",
                column: "MaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialInforId",
                table: "Materials",
                column: "MaterialInforId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialHistoryCard_MaterialInfors_MaterialInforId",
                table: "MaterialHistoryCard",
                column: "MaterialInforId",
                principalTable: "MaterialInfors",
                principalColumn: "Id");
        }
    }
}
