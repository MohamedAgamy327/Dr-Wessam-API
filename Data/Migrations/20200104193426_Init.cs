using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frequencys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(nullable: false),
                    EnglishName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabicName = table.Column<string>(nullable: false),
                    EnglishName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ArabicNotes = table.Column<string>(nullable: true),
                    EnglishNotes = table.Column<string>(nullable: true),
                    MedicineTypeId = table.Column<int>(nullable: false),
                    FrequencyId = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Frequencys_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineTypes_MedicineTypeId",
                        column: x => x.MedicineTypeId,
                        principalTable: "MedicineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    OccupationId = table.Column<int>(nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    KnowingId = table.Column<int>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    HusbandName = table.Column<string>(nullable: true),
                    HusbandOccupationId = table.Column<int>(nullable: true),
                    HusbandBirthday = table.Column<DateTime>(type: "date", nullable: true),
                    HusbandPhone = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    BMI = table.Column<string>(nullable: true),
                    Children = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Smoking = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Occupations_HusbandOccupationId",
                        column: x => x.HusbandOccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Knowings_KnowingId",
                        column: x => x.KnowingId,
                        principalTable: "Knowings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patients_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagonsis = table.Column<string>(nullable: true),
                    VisitDate = table.Column<DateTime>(nullable: false),
                    NextVisitDate = table.Column<DateTime>(nullable: false),
                    VisitType = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionInstructions",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false),
                    InstructionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionInstructions", x => new { x.InstructionId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_PrescriptionInstructions_Instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionInstructions_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionMedicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: false),
                    EnglishNotes = table.Column<string>(nullable: true),
                    ArabicNotes = table.Column<string>(nullable: true),
                    FrequencyId = table.Column<int>(nullable: true),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionMedicines", x => new { x.MedicineId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Frequencys_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionMedicines_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_FrequencyId",
                table: "Medicines",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineTypeId",
                table: "Medicines",
                column: "MedicineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HusbandOccupationId",
                table: "Patients",
                column: "HusbandOccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_KnowingId",
                table: "Patients",
                column: "KnowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_OccupationId",
                table: "Patients",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionInstructions_PrescriptionId",
                table: "PrescriptionInstructions",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_FrequencyId",
                table: "PrescriptionMedicines",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionMedicines_PrescriptionId",
                table: "PrescriptionMedicines",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrescriptionInstructions");

            migrationBuilder.DropTable(
                name: "PrescriptionMedicines");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Frequencys");

            migrationBuilder.DropTable(
                name: "MedicineTypes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Knowings");
        }
    }
}
