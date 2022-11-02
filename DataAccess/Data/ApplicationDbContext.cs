using Models;
using System;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<MobileFinanceServices> MoMobileFinanceServices { get; set; }
        public DbSet<MobileOperator> MobileOperators { get; set; }
        public DbSet<WalletAccount> WalletAccount { get; set; }
        public DbSet<CashWallet> CashWallets { get; set; }
        public DbSet<ServiceCashWallet> ServiceCashWallets { get; set; }
    }
}
