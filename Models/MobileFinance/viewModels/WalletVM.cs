using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Models.MobileFinance.viewModels
{
    public class WalletVM
    {
        public WalletAccount WalletAccount { get; set; }

        public IEnumerable<SelectListItem> MobileFinanceServicesList { get; set; }

        public IEnumerable<SelectListItem> MobileOperatorList { get; set; }
    }
}
