using Microsoft.EntityFrameworkCore.Migrations;

namespace TopfinAPI.Migrations
{
    public partial class Update_Table_AnalysisCenter_Props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "AnalysisCenters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "AnalysisCenters");
        }
    }
}
