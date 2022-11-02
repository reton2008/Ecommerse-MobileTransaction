using Models;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DataAccess.Data.Repository.IRepository
{
    public interface IMobileFinanceServices : IRepository<MobileFinanceServices>
    {
        IEnumerable<SelectListItem> GetServicesListForDropDown();

        void Update(MobileFinanceServices mobileFinanceServices);
    }
}
