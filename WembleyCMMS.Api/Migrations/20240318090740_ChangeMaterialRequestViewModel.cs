using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMaterialRequestViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialRequests");

            migrationBuilder.CreateTable(
                name: "MaterialRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialRequestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    CurrentNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    AdditionalNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    ExpectedNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequest_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequest_MaterialInforId",
                table: "MaterialRequest",
                column: "MaterialInforId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequest_MaterialRequestId",
                table: "MaterialRequest",
                column: "MaterialRequestId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialRequest");

            migrationBuilder.CreateTable(
                name: "MaterialRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaterialInforId = table.Column<int>(type: "int", nullable: false),
                    AdditionalNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedNumber = table.Column<decimal>(type: "decimal(30,10)", precision: 30, scale: 10, nullable: false),
                    MaterialRequestId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequests_MaterialInfors_MaterialInforId",
                        column: x => x.MaterialInforId,
                        principalTable: "MaterialInfors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequests_MaterialInforId",
                table: "MaterialRequests",
                column: "MaterialInforId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequests_MaterialRequestId",
                table: "MaterialRequests",
                column: "MaterialRequestId",
                unique: true);
        }
    }
}
