using System;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataAccess.Data.Repository.IRepository
{
    public interface IWalletAccountRepository : IRepository<WalletAccount>
    {
        IEnumerable<SelectListItem> GetWalletAccountListForDropDown();

        void Update(WalletAccount walletAccount);
    }
}
