using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace LEADSeCOMMERCE.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class OrderController : Controller
    {
        public readonly IUnitOfWork _iunitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _iunitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int Id) 
        {
            OrderViewModel orderVM = new OrderViewModel()
            {
                OrderHeader = _iunitOfWork.OrderHeader.GET(Id),
                OrderDetails = _iunitOfWork.OrderDetails.GETALL(filter: o => o.OrderHeaderId == Id)
            };
            return View(orderVM);
        }

        public IActionResult Approve(int id) 
        {
            var orderFromDb = _iunitOfWork.OrderHeader.GET(id);

            if (orderFromDb == null) 
            {
                return NotFound();
            }

            _iunitOfWork.OrderHeader.ChangeOrderStatus(id, SD.StatusApproved);

            return View(nameof(Index));
        }

        public IActionResult Reject(int id)
        {
            var orderFromDb = _iunitOfWork.OrderHeader.GET(id);

            if (orderFromDb == null)
            {
                return NotFound();
            }

            _iunitOfWork.OrderHeader.ChangeOrderStatus(id, SD.StatusRehected);

            return View(nameof(Index));
        }

        #region API Calls

        public IActionResult GetAllOrders()
        { 
            return Json(new {data = _iunitOfWork.OrderHeader.GETALL() });
        }

        public IActionResult GetAllPendingOrders()
        {
            return Json(new { data = _iunitOfWork.OrderHeader.GETALL(filter:o=>o.Status == SD.StatusSubmitted)});
        }

        public IActionResult GetAllApprovedOrders()
        {
            return Json(new { data = _iunitOfWork.OrderHeader.GETALL(filter: o => o.Status == SD.StatusApproved) });
        }
        #endregion
    }
}
