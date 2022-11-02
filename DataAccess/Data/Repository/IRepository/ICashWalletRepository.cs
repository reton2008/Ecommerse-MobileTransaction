using Models.MobileFinance;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccess.Data.Repository.IRepository
{
    public interface ICashWalletRepository : IRepository<CashWallet>
    {
        IEnumerable<SelectListItem> GetCashWalletListForDropDown();

        void Update(CashWallet cashWallet);
    }
}
