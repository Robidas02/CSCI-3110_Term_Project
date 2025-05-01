using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI_3110_Term_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovesInstances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_PokemonInstance_PokemonInstanceId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_PokemonInstanceId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "PokemonInstanceId",
                table: "Moves");

            migrationBuilder.CreateTable(
                name: "MovesPokemonInstance",
                columns: table => new
                {
                    KnownById = table.Column<int>(type: "int", nullable: false),
                    MoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovesPokemonInstance", x => new { x.KnownById, x.MoveId });
                    table.ForeignKey(
                        name: "FK_MovesPokemonInstance_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovesPokemonInstance_PokemonInstance_KnownById",
                        column: x => x.KnownById,
                        principalTable: "PokemonInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovesPokemonInstance_MoveId",
                table: "MovesPokemonInstance",
                column: "MoveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovesPokemonInstance");

            migrationBuilder.AddColumn<int>(
                name: "PokemonInstanceId",
                table: "Moves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonInstanceId",
                table: "Moves",
                column: "PokemonInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_PokemonInstance_PokemonInstanceId",
                table: "Moves",
                column: "PokemonInstanceId",
                principalTable: "PokemonInstance",
                principalColumn: "Id");
        }
    }
}
