using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class MaterialWithOutResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceResponseId",
                table: "Material",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceResponseId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
