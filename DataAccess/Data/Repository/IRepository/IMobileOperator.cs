using System;
using System.Text;
using System.Collections.Generic;
using Models.MobileFinance;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace DataAccess.Data.Repository.IRepository
{
    public interface IMobileOperator : IRepository<MobileOperator>
    {
        IEnumerable<SelectListItem> GetOperatorsListForDropDown();

        void Update(MobileOperator mobileFinanceServices);
    }
}
