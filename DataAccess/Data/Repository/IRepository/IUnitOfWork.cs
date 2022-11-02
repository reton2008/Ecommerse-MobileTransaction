using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IFrequencyRepository Frequency { get; }
        IServiceRepository Service { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IUserRepository User { get; }


        //Mobile Finance Services
        IMobileFinanceServices MobileFinanceServices { get; }
        IMobileOperator MobileOperator { get; }
        IWalletAccountRepository WalletAccount { get; }
        ICashWalletRepository CashWallet { get; }
        IServiceCashWalletRepository ServiceCashWallet { get; }
        void Save();
    }
}
