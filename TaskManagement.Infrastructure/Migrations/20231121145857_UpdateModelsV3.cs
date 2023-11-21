using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenericTaskStatusTypes_StatusTypes_StatusTypesId",
                table: "GenericTaskStatusTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenericTaskStatusTypes",
                table: "GenericTaskStatusTypes");

            migrationBuilder.DropColumn(
                name: "TaskStatusId",
                table: "GenericTaskStatusTypes");

            migrationBuilder.RenameColumn(
                name: "StatusTypesId",
                table: "GenericTaskStatusTypes",
                newName: "StatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GenericTaskStatusTypes_StatusTypesId",
                table: "GenericTaskStatusTypes",
                newName: "IX_GenericTaskStatusTypes_StatusTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenericTaskStatusTypes",
                table: "GenericTaskStatusTypes",
                columns: new[] { "GenericTaskId", "StatusTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenericTaskStatusTypes_StatusTypes_StatusTypeId",
                table: "GenericTaskStatusTypes",
                column: "StatusTypeId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenericTaskStatusTypes_StatusTypes_StatusTypeId",
                table: "GenericTaskStatusTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenericTaskStatusTypes",
                table: "GenericTaskStatusTypes");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "GenericTaskStatusTypes",
                newName: "StatusTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_GenericTaskStatusTypes_StatusTypeId",
                table: "GenericTaskStatusTypes",
                newName: "IX_GenericTaskStatusTypes_StatusTypesId");

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusId",
                table: "GenericTaskStatusTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenericTaskStatusTypes",
                table: "GenericTaskStatusTypes",
                columns: new[] { "GenericTaskId", "TaskStatusId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GenericTaskStatusTypes_StatusTypes_StatusTypesId",
                table: "GenericTaskStatusTypes",
                column: "StatusTypesId",
                principalTable: "StatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
