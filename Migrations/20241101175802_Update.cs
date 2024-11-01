using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorPatient",
                newName: "DoctorsId");

            migrationBuilder.AddColumn<string>(
                name: "Departament",
                table: "Employees",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Employees",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Employees",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NurseRoom",
                columns: table => new
                {
                    NursesId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseRoom", x => new { x.NursesId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_NurseRoom_Employees_NursesId",
                        column: x => x.NursesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseRoom_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NurseRoom_RoomsId",
                table: "NurseRoom",
                column: "RoomsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Employees_DoctorsId",
                table: "DoctorPatient",
                column: "DoctorsId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Employees_DoctorsId",
                table: "DoctorPatient");

            migrationBuilder.DropTable(
                name: "NurseRoom");

            migrationBuilder.DropColumn(
                name: "Departament",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DoctorsId",
                table: "DoctorPatient",
                newName: "DoctorId");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeDoctorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Departament = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Qualification = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Employees_EmployeeDoctorId",
                        column: x => x.EmployeeDoctorId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeNurseId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Employees_EmployeeNurseId",
                        column: x => x.EmployeeNurseId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeReceptionistId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptionists_Employees_EmployeeReceptionistId",
                        column: x => x.EmployeeReceptionistId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_EmployeeDoctorId",
                table: "Doctors",
                column: "EmployeeDoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_EmployeeNurseId",
                table: "Nurses",
                column: "EmployeeNurseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_EmployeeReceptionistId",
                table: "Receptionists",
                column: "EmployeeReceptionistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
