using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data.Repository;
using DataAccess.Data.Repository.IRepository;
using LEADSeCOMMERCE.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.viewModels;
using Utility;

namespace LEADSeCOMMERCE.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public CartViewModel CartVM { get; set; }

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CartVM = new CartViewModel
            {
                OrderHeader = new OrderHeader(),
                ServiceList = new List<Service>()
            };
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetObject<List<int>>(SD.SessionCart) != null) 
            {
                List<int> sessionList = new List<int>();
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);

                foreach (int serviceId in sessionList) 
                {
                    CartVM.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u=>u.Id==serviceId, includeProperties : ("Frequency,Category")));
                }
            }
            return View(CartVM);
        }

        public IActionResult Summary()
        {
            if (HttpContext.Session.GetObject<List<int>>(SD.SessionCart) != null)
            {
                List<int> sessionList = new List<int>();
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);

                foreach (int serviceId in sessionList)
                {
                    CartVM.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: ("Frequency,Category")));
                }
            }
            return View(CartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public IActionResult SummaryPost()
        {
            if (HttpContext.Session.GetObject<List<int>>(SD.SessionCart) != null)
            {
                List<int> sessionList = new List<int>();
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);
                CartVM.ServiceList = new List<Service>();
                foreach (int serviceId in sessionList)
                {
                    CartVM.ServiceList.Add(_unitOfWork.Service.GET(serviceId));
                    //CartVM.ServiceList.Add(_unitOfWork.Service.GetFirstOrDefault(u => u.Id == serviceId, includeProperties: ("Frequency,Category")));
                }
            }
            if (!ModelState.IsValid)
            {
                return View(CartVM);
            }
            else 
            {
                CartVM.OrderHeader.OrderDate = DateTime.Now;
                CartVM.OrderHeader.Status = SD.StatusSubmitted;
                CartVM.OrderHeader.ServiceCount = CartVM.ServiceList.Count;
                _unitOfWork.OrderHeader.Add(CartVM.OrderHeader);
                _unitOfWork.Save();

                foreach (var item in CartVM.ServiceList) 
                {
                    OrderDetails orderDetails = new OrderDetails
                    {
                        ServiceId = item.Id,
                        OrderHeaderId = CartVM.OrderHeader.Id,
                        ServiceName = item.Name,
                        Price = item.Price
                    };

                    _unitOfWork.OrderDetails.Add(orderDetails);
                    _unitOfWork.Save();
                }
                HttpContext.Session.SetObject(SD.SessionCart, new List<int>());
                return RedirectToAction("OrderConfirmation", "Cart", new { id = CartVM.OrderHeader.Id });
            }
            
        }

        public IActionResult OrderConfirmation(int id) 
        {
            return View(id);
        }

        public IActionResult Remove(int serviceId) 
        {
            List<int> sessionList = new List<int>();
            sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);
            sessionList.Remove(serviceId);

            HttpContext.Session.SetObject(SD.SessionCart, sessionList);

            return RedirectToAction(nameof(Index));
        }
    }
}