using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addWallentAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(nullable: false),
                    MobFinSerId = table.Column<int>(nullable: false),
                    MobOperatorId = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletAccount_MoMobileFinanceServices_MobFinSerId",
                        column: x => x.MobFinSerId,
                        principalTable: "MoMobileFinanceServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalletAccount_MobileOperators_MobOperatorId",
                        column: x => x.MobOperatorId,
                        principalTable: "MobileOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletAccount_MobFinSerId",
                table: "WalletAccount",
                column: "MobFinSerId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletAccount_MobOperatorId",
                table: "WalletAccount",
                column: "MobOperatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletAccount");
        }
    }
}
