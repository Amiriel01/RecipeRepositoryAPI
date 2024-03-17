using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeRepository.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergenCategoryRecipeDetails",
                columns: table => new
                {
                    AllergenCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenCategoryRecipeDetails", x => new { x.AllergenCategoriesId, x.RecipeDetailsId });
                    table.ForeignKey(
                        name: "FK_AllergenCategoryRecipeDetails_AllergenCategories_AllergenCategoriesId",
                        column: x => x.AllergenCategoriesId,
                        principalTable: "AllergenCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenCategoryRecipeDetails_RecipeDetails_RecipeDetailsId",
                        column: x => x.RecipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealCategoryRecipeDetails",
                columns: table => new
                {
                    MealCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategoryRecipeDetails", x => new { x.MealCategoriesId, x.RecipeDetailsId });
                    table.ForeignKey(
                        name: "FK_MealCategoryRecipeDetails_MealCategories_MealCategoriesId",
                        column: x => x.MealCategoriesId,
                        principalTable: "MealCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealCategoryRecipeDetails_RecipeDetails_RecipeDetailsId",
                        column: x => x.RecipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenCategoryRecipeDetails_RecipeDetailsId",
                table: "AllergenCategoryRecipeDetails",
                column: "RecipeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MealCategoryRecipeDetails_RecipeDetailsId",
                table: "MealCategoryRecipeDetails",
                column: "RecipeDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenCategoryRecipeDetails");

            migrationBuilder.DropTable(
                name: "MealCategoryRecipeDetails");
        }
    }
}
