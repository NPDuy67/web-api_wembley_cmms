using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WembleyCMMS.Api.Migrations
{
    /// <inheritdoc />
    public partial class cleancode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "InputTabuSearchs");

            migrationBuilder.DropTable(
                name: "Sounds");

            migrationBuilder.DropSequence(
                name: "imageeq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "inputtabusearcheq",
                schema: "application");

            migrationBuilder.DropSequence(
                name: "soundeq",
                schema: "application");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "imageeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "inputtabusearcheq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "soundeq",
                schema: "application",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputTabuSearchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InputTabuSearchId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JsonString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTabuSearchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SoundId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sounds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ImageId",
                table: "Images",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputTabuSearchs_InputTabuSearchId",
                table: "InputTabuSearchs",
                column: "InputTabuSearchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sounds_SoundId",
                table: "Sounds",
                column: "SoundId",
                unique: true);
        }
    }
}
