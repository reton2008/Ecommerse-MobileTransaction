using System;
using System.Linq;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data.Repository.IRepository;

namespace DataAccess.Data.Repository
{
    public class CashWalletRepository : Repository<CashWallet>, ICashWalletRepository
    {
        private readonly ApplicationDbContext _db;

        public CashWalletRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCashWalletListForDropDown()
        {
            return _db.CashWallets.Select(i => new SelectListItem()
            {
                Text = i.CashWalletName,
                Value = i.Id.ToString()
            });
        }

        public void Update(CashWallet cashWallet)
        {
            var objFromDb = _db.CashWallets.FirstOrDefault(s => s.Id == cashWallet.Id);

            objFromDb.CashWalletName = cashWallet.CashWalletName;
            objFromDb.CashShortName = cashWallet.CashShortName;
            objFromDb.Balance = cashWallet.Balance;
            objFromDb.Active = cashWallet.Active;

            _db.SaveChanges();
        }
    }
}
