using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoveIt.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentRegistrationsToClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Trainers_TrainerIDId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRegistrations_Classes_ClassIdId",
                table: "ClassRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRegistrations_Members_MemberIDId",
                table: "ClassRegistrations");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TrainerIDId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TrainerIDId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "MemberIDId",
                table: "ClassRegistrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassIdId",
                table: "ClassRegistrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRegistrations_Classes_ClassIdId",
                table: "ClassRegistrations",
                column: "ClassIdId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRegistrations_Members_MemberIDId",
                table: "ClassRegistrations",
                column: "MemberIDId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRegistrations_Classes_ClassIdId",
                table: "ClassRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassRegistrations_Members_MemberIDId",
                table: "ClassRegistrations");

            migrationBuilder.AlterColumn<int>(
                name: "MemberIDId",
                table: "ClassRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassIdId",
                table: "ClassRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerIDId",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainerIDId",
                table: "Classes",
                column: "TrainerIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Trainers_TrainerIDId",
                table: "Classes",
                column: "TrainerIDId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRegistrations_Classes_ClassIdId",
                table: "ClassRegistrations",
                column: "ClassIdId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRegistrations_Members_MemberIDId",
                table: "ClassRegistrations",
                column: "MemberIDId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
