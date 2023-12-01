using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreAppProjectMvc.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddPublishForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPublish",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPublish",
                table: "Products");
        }
    }
}
