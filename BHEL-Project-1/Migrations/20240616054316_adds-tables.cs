using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHEL_Project_1.Migrations
{
    /// <inheritdoc />
    public partial class addstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentMasters",
                columns: table => new
                {
                    ComponentMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Component_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Component_Ref_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updated_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Updated_On = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentMasters", x => x.ComponentMasterId);
                });

            migrationBuilder.CreateTable(
                name: "ComponentTypesMaster",
                columns: table => new
                {
                    ComponentTypeMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Ind = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Doc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_BOI = table.Column<bool>(type: "bit", nullable: false),
                    Applicable_Item_Id = table.Column<int>(type: "int", nullable: false),
                    ComponentMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypesMaster", x => x.ComponentTypeMasterId);
                    table.ForeignKey(
                        name: "FK_ComponentTypesMaster_ComponentMasters_ComponentMasterId",
                        column: x => x.ComponentMasterId,
                        principalTable: "ComponentMasters",
                        principalColumn: "ComponentMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentTypesMaster_ComponentMasterId",
                table: "ComponentTypesMaster",
                column: "ComponentMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentTypesMaster");

            migrationBuilder.DropTable(
                name: "ComponentMasters");
        }
    }
}
