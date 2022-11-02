using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addServiceCashWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCashWallets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    WalletId = table.Column<int>(nullable: false),
                    WalletAccoutId = table.Column<int>(nullable: true),
                    CashId = table.Column<int>(nullable: false),
                    CashWallettId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCashWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCashWallets_CashWallets_CashWallettId",
                        column: x => x.CashWallettId,
                        principalTable: "CashWallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceCashWallets_WalletAccount_WalletAccoutId",
                        column: x => x.WalletAccoutId,
                        principalTable: "WalletAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCashWallets_CashWallettId",
                table: "ServiceCashWallets",
                column: "CashWallettId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCashWallets_WalletAccoutId",
                table: "ServiceCashWallets",
                column: "WalletAccoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceCashWallets");
        }
    }
}
