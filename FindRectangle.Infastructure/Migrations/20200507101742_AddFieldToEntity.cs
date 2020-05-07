using Microsoft.EntityFrameworkCore.Migrations;

namespace FindRectangle.Infastructure.Migrations
{
    public partial class AddFieldToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PointGroups",
                table: "PointGroups");

            migrationBuilder.RenameTable(
                name: "PointGroups",
                newName: "GroupPoints");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Points",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointGroupId",
                table: "Points",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Points",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Points",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "GroupPoints",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupPoints",
                table: "GroupPoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Points_PointGroupId",
                table: "Points",
                column: "PointGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_GroupPoints_PointGroupId",
                table: "Points",
                column: "PointGroupId",
                principalTable: "GroupPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_GroupPoints_PointGroupId",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_PointGroupId",
                table: "Points");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupPoints",
                table: "GroupPoints");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PointGroupId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "X",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "GroupPoints");

            migrationBuilder.RenameTable(
                name: "GroupPoints",
                newName: "PointGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointGroups",
                table: "PointGroups",
                column: "Id");
        }
    }
}
