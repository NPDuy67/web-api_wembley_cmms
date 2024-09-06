using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixConflictWithMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");
        }
    }
}
