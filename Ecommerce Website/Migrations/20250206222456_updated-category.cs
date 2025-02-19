using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class updatedcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category_Name",
                table: "tbl_category",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "category_Id",
                table: "tbl_category",
                newName: "category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "tbl_category",
                newName: "category_Name");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "tbl_category",
                newName: "category_Id");
        }
    }
}
