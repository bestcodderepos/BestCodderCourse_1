using Microsoft.EntityFrameworkCore.Migrations;

namespace BestCodder.DataAccess.Migrations
{
    public partial class CourseOrderInfoTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseOrderInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StripeSessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoursePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaymentSuccessfull = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOrderInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseOrderInfos_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOrderInfos_CourseId",
                table: "CourseOrderInfos",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOrderInfos");
        }
    }
}
