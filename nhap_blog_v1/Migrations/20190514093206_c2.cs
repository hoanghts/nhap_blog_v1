using Microsoft.EntityFrameworkCore.Migrations;

namespace nhap_blog_v1.Migrations
{
    public partial class c2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Mê Phim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
