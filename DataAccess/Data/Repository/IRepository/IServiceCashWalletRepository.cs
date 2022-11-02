using System;
using System.Text;
using Models.MobileFinance;
using System.Collections.Generic;

namespace DataAccess.Data.Repository.IRepository
{
    public interface IServiceCashWalletRepository : IRepository<ServiceCashWallet>
    {
        void Update(ServiceCashWallet serviceCashWallet);
    }
}
