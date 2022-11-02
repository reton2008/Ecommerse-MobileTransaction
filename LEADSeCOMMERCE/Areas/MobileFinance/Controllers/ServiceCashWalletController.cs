using Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Models.MobileFinance;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models.MobileFinance.viewModels;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Data.Repository.IRepository;

namespace LEADSeCOMMERCE.Areas.MobileFinance.Controllers
{
    [Authorize]
    [Area("MobileFinance")]

    public class ServiceCashWalletController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceCashWalletController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ServiceCashWalletVM ServiceCashWalletVM { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ServiceCashWalletVM = new ServiceCashWalletVM()
            {
                ServiceCashWallet = new ServiceCashWallet(),
                ServiceWalletList = _unitOfWork.WalletAccount.GetWalletAccountListForDropDown(),
                CashWalletList = _unitOfWork.CashWallet.GetCashWalletListForDropDown(),
            };

            if (id != null)
            {
                ServiceCashWalletVM.ServiceCashWallet = _unitOfWork.ServiceCashWallet.GET(id.GetValueOrDefault());
            }

            return View(ServiceCashWalletVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServiceCashWalletVM serviceCashWalletVM)
        {
            if (ModelState.IsValid)
            {
                if (serviceCashWalletVM.ServiceCashWallet.Id == 0)
                {
                    _unitOfWork.ServiceCashWallet.Add(serviceCashWalletVM.ServiceCashWallet);
                }
                else
                {
                    _unitOfWork.ServiceCashWallet.Update(serviceCashWalletVM.ServiceCashWallet);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(serviceCashWalletVM);
            }
        }
    }
}
