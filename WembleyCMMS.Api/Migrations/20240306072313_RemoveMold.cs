using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentMaterials_Molds_MoldId",
                table: "EquipmentMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Molds_MoldId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_Molds_MoldId",
                table: "MaintenanceResponses");

            migrationBuilder.DropTable(
                name: "MoldInfors");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "KitTests");

            migrationBuilder.DropTable(
                name: "Molds");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceResponses_MoldId",
                table: "MaintenanceResponses");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_MoldId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentMaterials_MoldId",
                table: "EquipmentMaterials");

            migrationBuilder.DropColumn(
                name: "MoldId",
                table: "MaintenanceResponses");

            migrationBuilder.DropColumn(
                name: "MoldId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "MoldId",
                table: "EquipmentMaterials");

            migrationBuilder.DropSequence(
                name: "kittesteq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "moldeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "moldinforeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "producteq",
                schema: "application");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "kittesteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "moldeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "moldinforeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "producteq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "MoldId",
                table: "MaintenanceResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldId",
                table: "EquipmentMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KitTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KitTestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoldInfors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cavity = table.Column<int>(type: "int", nullable: true),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoldInforId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoldInfors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Molds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MTBFId = table.Column<int>(type: "int", nullable: true),
                    MTTFId = table.Column<int>(type: "int", nullable: true),
                    OEEId = table.Column<int>(type: "int", nullable: true),
                    Cavity = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoldId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleWorkingTimes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedTime = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Molds_PerformanceIndexs_MTBFId",
                        column: x => x.MTBFId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Molds_PerformanceIndexs_MTTFId",
                        column: x => x.MTTFId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Molds_PerformanceIndexs_OEEId",
                        column: x => x.OEEId,
                        principalTable: "PerformanceIndexs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    KitTestId = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoldId = table.Column<int>(type: "int", nullable: true),
                    StandardId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standards_KitTests_KitTestId",
                        column: x => x.KitTestId,
                        principalTable: "KitTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Standards_Molds_MoldId",
                        column: x => x.MoldId,
                        principalTable: "Molds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_MoldId",
                table: "MaintenanceResponses",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MoldId",
                table: "MaintenanceRequests",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaterials_MoldId",
                table: "EquipmentMaterials",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_KitTests_KitTestId",
                table: "KitTests",
                column: "KitTestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoldInfors_MoldInforId",
                table: "MoldInfors",
                column: "MoldInforId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MoldId",
                table: "Molds",
                column: "MoldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MTBFId",
                table: "Molds",
                column: "MTBFId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_MTTFId",
                table: "Molds",
                column: "MTTFId");

            migrationBuilder.CreateIndex(
                name: "IX_Molds_OEEId",
                table: "Molds",
                column: "OEEId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MoldId",
                table: "Products",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Standards_KitTestId",
                table: "Standards",
                column: "KitTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_MoldId",
                table: "Standards",
                column: "MoldId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_StandardId",
                table: "Standards",
                column: "StandardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentMaterials_Molds_MoldId",
                table: "EquipmentMaterials",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Molds_MoldId",
                table: "MaintenanceRequests",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_Molds_MoldId",
                table: "MaintenanceResponses",
                column: "MoldId",
                principalTable: "Molds",
                principalColumn: "Id");
        }
    }
}
