using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;

        public HomeController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orderList = await _orderService.GetAllOrdersAsync(null, false);
            List<OrderViewModel> orders = orderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                City = o.City,
                Phone = o.Phone,
                Email = o.Email,
                FirstName = o.FirstName,
                LastName = o.LastName,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems.Select(oi => new OrderItemViewModel
                {
                    OrderItemId = oi.Id,
                    AdvertId = oi.AdvertId,
                    TeacherName = oi.Advert.Teacher.User.FirstName + oi.Advert.Teacher.User.LastName,
                    TeacherUrl = oi.Advert.Teacher.Url,
                    ImageUrl = oi.Advert.Teacher.User.Image.Url,
                    ItemPrice = oi.Price,
                    Amount = oi.Amount
                }).ToList()
            }).ToList();
            return View(orders);
        }

    }
}
