using System;
using System.Linq;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data.Repository.IRepository;

namespace DataAccess.Data.Repository 
{
    public class ServiceCashWalletRepository : Repository<ServiceCashWallet>, IServiceCashWalletRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceCashWalletRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ServiceCashWallet serviceCashWallet)
        {
            var objFromDb = _db.ServiceCashWallets.FirstOrDefault(s => s.Id == serviceCashWallet.Id);

            objFromDb.Name = serviceCashWallet.Name;
            objFromDb.WalletId = serviceCashWallet.WalletId;
            objFromDb.CashId = serviceCashWallet.CashId;
            objFromDb.Active = serviceCashWallet.Active;

            _db.SaveChanges();
        }
    }
}
