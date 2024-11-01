using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class Finish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NurseRoom",
                table: "NurseRoom");

            migrationBuilder.DropIndex(
                name: "IX_NurseRoom_RoomsId",
                table: "NurseRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPatient_PatientsId",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_Billings_PatientId",
                table: "Billings");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "TestReports",
                newName: "PatientId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NurseRoom",
                table: "NurseRoom",
                columns: new[] { "RoomsId", "NursesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                columns: new[] { "PatientsId", "DoctorsId" });

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_PatientId",
                table: "TestReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_RoomId",
                table: "Patients",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_NurseRoom_NursesId",
                table: "NurseRoom",
                column: "NursesId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_DoctorsId",
                table: "DoctorPatient",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PatientId",
                table: "Billings",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Rooms_RoomId",
                table: "Patients",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestReports_Patients_PatientId",
                table: "TestReports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Rooms_RoomId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_TestReports_Patients_PatientId",
                table: "TestReports");

            migrationBuilder.DropIndex(
                name: "IX_TestReports_PatientId",
                table: "TestReports");

            migrationBuilder.DropIndex(
                name: "IX_Patients_RoomId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NurseRoom",
                table: "NurseRoom");

            migrationBuilder.DropIndex(
                name: "IX_NurseRoom_NursesId",
                table: "NurseRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_DoctorPatient_DoctorsId",
                table: "DoctorPatient");

            migrationBuilder.DropIndex(
                name: "IX_Billings_PatientId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "TestReports",
                newName: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NurseRoom",
                table: "NurseRoom",
                columns: new[] { "NursesId", "RoomsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                columns: new[] { "DoctorsId", "PatientsId" });

            migrationBuilder.CreateIndex(
                name: "IX_NurseRoom_RoomsId",
                table: "NurseRoom",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPatient_PatientsId",
                table: "DoctorPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PatientId",
                table: "Billings",
                column: "PatientId",
                unique: true);
        }
    }
}
