using DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            //Online Shopping Cart

            Category = new CategoryRepository(_db);

            Frequency = new FrequencyRepository(_db);

            Service = new ServiceRepository(_db);

            OrderHeader = new OrderHeaderRepository(_db);

            OrderDetails= new OrderDetailsRepository(_db);

            OrderDetails= new OrderDetailsRepository(_db);

            User= new UserRepository(_db);

            //Mobile Finance Services

            MobileFinanceServices = new MobileFinanceServicesRepository(_db);

            MobileOperator = new MobileOperatorRepository(_db);

            WalletAccount = new WalletAccountRepository(_db);

            CashWallet = new CashWalletRepository(_db);

            ServiceCashWallet = new ServiceCashWalletRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public IFrequencyRepository Frequency {get; private set; }

        public IServiceRepository Service {get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailsRepository OrderDetails { get; private set; }

        public IUserRepository User { get; private set; }

        public IMobileFinanceServices MobileFinanceServices { get; private set; }

        public IMobileOperator MobileOperator { get; private set; }

        public IWalletAccountRepository WalletAccount { get; private set; }

        public ICashWalletRepository CashWallet { get; private set; }

        public IServiceCashWalletRepository ServiceCashWallet { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
