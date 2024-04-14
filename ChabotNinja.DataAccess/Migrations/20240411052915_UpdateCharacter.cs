using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatbotNinja.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Personalities_PersonalityId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PersonalityId1",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PersonalityId1",
                table: "Characters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalityId1",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PersonalityId1",
                table: "Characters",
                column: "PersonalityId1",
                unique: true,
                filter: "[PersonalityId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Personalities_PersonalityId1",
                table: "Characters",
                column: "PersonalityId1",
                principalTable: "Personalities",
                principalColumn: "PersonalityId");
        }
    }
}
