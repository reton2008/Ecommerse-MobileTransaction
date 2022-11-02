using Models;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data.Repository.IRepository;

namespace DataAccess.Data.Repository
{
    public class MobileFinanceServicesRepository : Repository<MobileFinanceServices>, IMobileFinanceServices
    {
        private readonly ApplicationDbContext _db;

        public MobileFinanceServicesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetServicesListForDropDown()
        {
            return _db.MoMobileFinanceServices.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(MobileFinanceServices mobileFinanceServices)
        {
            var objFromDb = _db.MoMobileFinanceServices.FirstOrDefault(s => s.Id == mobileFinanceServices.Id);

            objFromDb.Name = mobileFinanceServices.Name;
            objFromDb.ActivationDate = mobileFinanceServices.ActivationDate;
            objFromDb.Active = mobileFinanceServices.Active;

            _db.SaveChanges();
        }
    }
}
