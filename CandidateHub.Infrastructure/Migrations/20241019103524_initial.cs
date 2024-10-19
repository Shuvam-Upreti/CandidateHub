using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateDetail",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CallTimeInterval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LinkedInProfileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GitHubProfileUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FreeTextComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Candidat__DF539B9C9FD42303", x => x.CandidateId);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Candidat__A9D1053462AE9A2F",
                table: "CandidateDetail",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDetail");
        }
    }
}
