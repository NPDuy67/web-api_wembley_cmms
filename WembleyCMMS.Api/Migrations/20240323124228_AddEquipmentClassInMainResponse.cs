using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentClassInMainResponse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_Persons_ResponsiblePersonId",
                table: "MaintenanceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "MaintenanceObject",
                table: "MaintenanceResponses");

            migrationBuilder.DropColumn(
                name: "Sounds",
                table: "MaintenanceResponses");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceResponseId",
                table: "Material",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "MaintenanceResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "MaintenanceResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "MaintenanceResponses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Problem",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedStart",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentClassId",
                table: "MaintenanceResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RequestedPriority",
                table: "MaintenanceRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceResponses_EquipmentClassId",
                table: "MaintenanceResponses",
                column: "EquipmentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_EquipmentClasses_EquipmentClassId",
                table: "MaintenanceResponses",
                column: "EquipmentClassId",
                principalTable: "EquipmentClasses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_Persons_ResponsiblePersonId",
                table: "MaintenanceResponses",
                column: "ResponsiblePersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_EquipmentClasses_EquipmentClassId",
                table: "MaintenanceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceResponses_Persons_ResponsiblePersonId",
                table: "MaintenanceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceResponses_EquipmentClassId",
                table: "MaintenanceResponses");

            migrationBuilder.DropColumn(
                name: "EquipmentClassId",
                table: "MaintenanceResponses");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceResponseId",
                table: "Material",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "MaintenanceResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "MaintenanceResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "MaintenanceResponses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Problem",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedStart",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MaintenanceResponses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceObject",
                table: "MaintenanceResponses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sounds",
                table: "MaintenanceResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequestedPriority",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceResponses_Persons_ResponsiblePersonId",
                table: "MaintenanceResponses",
                column: "ResponsiblePersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_MaintenanceResponses_MaintenanceResponseId",
                table: "Material",
                column: "MaintenanceResponseId",
                principalTable: "MaintenanceResponses",
                principalColumn: "Id");
        }
    }
}
