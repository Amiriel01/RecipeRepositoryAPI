using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeRepository.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergenCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergenUrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergenName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealUrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeUrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenCategories");

            migrationBuilder.DropTable(
                name: "MealCategories");

            migrationBuilder.DropTable(
                name: "RecipeDetails");
        }
    }
}
