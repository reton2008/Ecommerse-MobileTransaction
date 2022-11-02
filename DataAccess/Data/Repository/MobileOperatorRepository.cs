using System.Linq;
using System.Text;
using Models.MobileFinance;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Data.Repository.IRepository;
using System.Collections.Generic;

namespace DataAccess.Data.Repository 
{
    public class MobileOperatorRepository : Repository<MobileOperator>, IMobileOperator
    {
        private readonly ApplicationDbContext _db;

        public MobileOperatorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetOperatorsListForDropDown()
        {

            return _db.MobileOperators.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(MobileOperator mobileOperator)
        {
            var objFromDb = _db.MobileOperators.FirstOrDefault(s => s.Id == mobileOperator.Id);

            objFromDb.Name = mobileOperator.Name;
            objFromDb.OpShortName = mobileOperator.OpShortName;
            objFromDb.Active = mobileOperator.Active;

            _db.SaveChanges();
        }
    }
}
