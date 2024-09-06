using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Equipments");

            migrationBuilder.CreateSequence(
                name: "equipmentclasseq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentClassId",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EquipmentClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EquipmentClassId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentClassId",
                table: "Equipments",
                column: "EquipmentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentClasses_EquipmentClassId",
                table: "EquipmentClasses",
                column: "EquipmentClassId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentClasses_EquipmentClassId",
                table: "Equipments",
                column: "EquipmentClassId",
                principalTable: "EquipmentClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentClasses_EquipmentClassId",
                table: "Equipments");

            migrationBuilder.DropTable(
                name: "EquipmentClasses");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EquipmentClassId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EquipmentClassId",
                table: "Equipments");

            migrationBuilder.DropSequence(
                name: "equipmentclasseq",
                schema: "application");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Equipments",
                type: "int",
                maxLength: 60,
                nullable: true);
        }
    }
}
