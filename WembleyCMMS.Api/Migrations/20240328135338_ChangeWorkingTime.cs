using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWorkingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_WorkingTimes_WorkingTimeId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_MaintenanceRequests_RequestId",
                table: "MaintenanceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_WorkingTimes_WorkingTimeId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_WorkingTimeId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_WorkingTimeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "WorkingTimeId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "WorkingTimeId",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "WorkingTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResponsiblePersonId",
                table: "WorkingTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_EquipmentId",
                table: "WorkingTimes",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingTimes_ResponsiblePersonId",
                table: "WorkingTimes",
                column: "ResponsiblePersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_MaintenanceRequests_RequestId",
                table: "MaintenanceResponses",
                column: "RequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_Equipments_EquipmentId",
                table: "WorkingTimes",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingTimes_Persons_ResponsiblePersonId",
                table: "WorkingTimes",
                column: "ResponsiblePersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_MaintenanceRequests_RequestId",
                table: "MaintenanceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_Equipments_EquipmentId",
                table: "WorkingTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingTimes_Persons_ResponsiblePersonId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_EquipmentId",
                table: "WorkingTimes");

            migrationBuilder.DropIndex(
                name: "IX_WorkingTimes_ResponsiblePersonId",
                table: "WorkingTimes");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "WorkingTimes");

            migrationBuilder.DropColumn(
                name: "ResponsiblePersonId",
                table: "WorkingTimes");

            migrationBuilder.AddColumn<int>(
                name: "WorkingTimeId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingTimeId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_WorkingTimeId",
                table: "Persons",
                column: "WorkingTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_WorkingTimeId",
                table: "Equipments",
                column: "WorkingTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_WorkingTimes_WorkingTimeId",
                table: "Equipments",
                column: "WorkingTimeId",
                principalTable: "WorkingTimes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_MaintenanceRequests_RequestId",
                table: "MaintenanceResponses",
                column: "RequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_WorkingTimes_WorkingTimeId",
                table: "Persons",
                column: "WorkingTimeId",
                principalTable: "WorkingTimes",
                principalColumn: "Id");
        }
    }
}
