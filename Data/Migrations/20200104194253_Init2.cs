using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FrequencyId",
                table: "PrescriptionMedicines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FrequencyId",
                table: "PrescriptionMedicines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
