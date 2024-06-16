using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHEL_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class addsViews1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentTypesMaster_ComponentMasters_ComponentMasterId",
                table: "ComponentTypesMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentTypesMaster",
                table: "ComponentTypesMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentMasters",
                table: "ComponentMasters");

            migrationBuilder.RenameTable(
                name: "ComponentTypesMaster",
                newName: "ComponentTypeMaster");

            migrationBuilder.RenameTable(
                name: "ComponentMasters",
                newName: "ComponentMaster");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentTypesMaster_ComponentMasterId",
                table: "ComponentTypeMaster",
                newName: "IX_ComponentTypeMaster_ComponentMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentTypeMaster",
                table: "ComponentTypeMaster",
                column: "ComponentTypeMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentMaster",
                table: "ComponentMaster",
                column: "ComponentMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentTypeMaster_ComponentMaster_ComponentMasterId",
                table: "ComponentTypeMaster",
                column: "ComponentMasterId",
                principalTable: "ComponentMaster",
                principalColumn: "ComponentMasterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentTypeMaster_ComponentMaster_ComponentMasterId",
                table: "ComponentTypeMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentTypeMaster",
                table: "ComponentTypeMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentMaster",
                table: "ComponentMaster");

            migrationBuilder.RenameTable(
                name: "ComponentTypeMaster",
                newName: "ComponentTypesMaster");

            migrationBuilder.RenameTable(
                name: "ComponentMaster",
                newName: "ComponentMasters");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentTypeMaster_ComponentMasterId",
                table: "ComponentTypesMaster",
                newName: "IX_ComponentTypesMaster_ComponentMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentTypesMaster",
                table: "ComponentTypesMaster",
                column: "ComponentTypeMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentMasters",
                table: "ComponentMasters",
                column: "ComponentMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentTypesMaster_ComponentMasters_ComponentMasterId",
                table: "ComponentTypesMaster",
                column: "ComponentMasterId",
                principalTable: "ComponentMasters",
                principalColumn: "ComponentMasterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
