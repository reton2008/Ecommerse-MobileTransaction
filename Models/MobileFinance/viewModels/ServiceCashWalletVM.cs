using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.MobileFinance.viewModels
{
    public class ServiceCashWalletVM
    {
        public ServiceCashWallet ServiceCashWallet { get; set; }

        public IEnumerable<SelectListItem> CashWalletList { get; set; }

        public IEnumerable<SelectListItem> ServiceWalletList { get; set; }
    }
}
