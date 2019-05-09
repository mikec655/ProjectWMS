using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Blogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(50)")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Blogs",
                type: "int(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
