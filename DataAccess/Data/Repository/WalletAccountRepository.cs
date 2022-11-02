using Models;
using System;
using System.Linq;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data.Repository.IRepository;

namespace DataAccess.Data.Repository
{
    public class WalletAccountRepository : Repository<WalletAccount>, IWalletAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public WalletAccountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetWalletAccountListForDropDown()
        {

            return _db.WalletAccount.Select(i => new SelectListItem()
            {
                Text = i.PhoneNumber + "-" +i.MobileFinanceServices.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(WalletAccount walletAccount)
        {
            var objFromDb = _db.WalletAccount.FirstOrDefault(s => s.Id == walletAccount.Id);

            objFromDb.PhoneNumber = walletAccount.PhoneNumber;
            objFromDb.MobFinSerId = walletAccount.MobFinSerId;
            objFromDb.MobOperatorId = walletAccount.MobOperatorId;
            objFromDb.Balance = walletAccount.Balance;
            objFromDb.Active = walletAccount.Active;

            _db.SaveChanges();
        }
    }
}
