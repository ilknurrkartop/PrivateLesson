using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Models.ViewModels;
using System.Net;
using System;
using Iyzipay.Model;
using Iyzipay;
using Iyzipay.Request;

namespace PrivateLesson.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly INotyfService _notyfService;

        public CartController(UserManager<User> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, INotyfService notyfService, IStudentService studentService, ITeacherService teacherService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _notyfService = notyfService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.Id,
                    AdvertId = ci.AdvertId,
                    TeacherName = ci.Advert.Teacher.User.FirstName + ci.Advert.Teacher.User.LastName,
                    ItemPrice = ci.Advert.Price,
                    TeacherGraduation = ci.Advert.Teacher.Graduation,
                    TeacherUrl = ci.Advert.Teacher.Url,
                    BranchName = ci.Advert.Branch.BranchName,
                    Description = ci.Advert.Description,
                    Amount = ci.Amount,
                    ImageUrl = ci.Advert.Teacher.User.Image.Url
                }).ToList()
            };
            return View(cartViewModel);
        }


        [HttpPost]
        public IActionResult AddToCart(int Id, int Amount = 1)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            _cartService.AddToCart(userId, Id, Amount);
            _notyfService.Success("Ders sepetinize başarıyla eklenmiştir");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var cartItem = await _cartItemService.GetByIdAsync(id);
            _cartItemService.Delete(cartItem);

            _notyfService.Information("Ders sepetten kaldırılmıştır", 2);
            return RedirectToAction("Index");
        }
        public IActionResult ClearCart(int id)
        {
            _cartItemService.ClearCart(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAmount(CartItemViewModel cartItemViewModel)
        {
            if (ModelState.IsValid)
            {
                await _cartItemService.ChangeAmountAsync(cartItemViewModel.CartItemId, cartItemViewModel.Amount);
            }
            else
            {
                _notyfService.Information("Minimum 1 adet olmalıdır", 5);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var cart = await _cartService.GetCartByUserId(userId);

            OrderViewModel orderViewModel = new OrderViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                Phone = user.Phone,
                Email = user.Email,
                Cart = new CartViewModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(
                       ci => new CartItemViewModel
                       {
                           CartItemId = ci.Id,
                           AdvertId = ci.AdvertId,
                           TeacherName = ci.Advert.Teacher.User.FirstName + " " + ci.Advert.Teacher.User.LastName,
                           ItemPrice = ci.Advert.Price,
                           Amount = ci.Amount,
                           TeacherGraduation = ci.Advert.Teacher.Graduation,
                           ImageUrl = ci.Advert.Teacher.User.Image.Url,
                           Description = ci.Advert.Description,
                           BranchName = ci.Advert.Branch.BranchName
                       }).ToList()
                }
            };
            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel orderViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            if (ModelState.IsValid)
            {

                orderViewModel.Cart = new CartViewModel
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                    {
                        CartItemId = ci.Id,
                        AdvertId = ci.AdvertId,
                        TeacherName = ci.Advert.Teacher.User.FirstName + " " + ci.Advert.Teacher.User.LastName,
                        ItemPrice = ci.Advert.Price,
                        Amount = ci.Amount,
                        TeacherGraduation = ci.Advert.Teacher.Graduation,
                        ImageUrl = ci.Advert.Teacher.User.Image.Url,
                        Description = ci.Advert.Description,
                        BranchName = ci.Advert.Branch.BranchName
                    }).ToList()
                };
                //Normalde burada ÖDEME İŞLEMLERİNİ yaptıracağız.

                //2)Eğer kart numarası geçerliyse ve başka sorun yoksa ödemeyi alacağız.
                //3)Ödeme de başarılıysa SATIŞ İŞLEMLERİNİ yapacağız, yani Order'a kayıt!

                //Önce kart numarasını kontrol ediyoruz.
                if (!CardNumberControl(orderViewModel.CardNumber))
                {
                    _notyfService.Error("Geçersiz kart numarası!");
                    return View(orderViewModel);
                }

                Payment payment = PaymentProcess(orderViewModel);
                if (payment.Status == "success")
                {
                    SaveOrder(orderViewModel, userId);
                    _cartItemService.ClearCart(orderViewModel.Cart.CartId);
                    _notyfService.Success("Ödemeniz alınmış ve siparişiniz oluşturulmuştur!");
                    return RedirectToAction("Index", "Home");
                }
                _notyfService.Error("Bir sorun oluştu!");
            }
            orderViewModel.Cart = new CartViewModel
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.Id,
                    AdvertId = ci.AdvertId,
                    TeacherName = ci.Advert.Teacher.User.FirstName + ci.Advert.Teacher.User.LastName,
                    ItemPrice = ci.Advert.Price,
                    Amount = ci.Amount,
                    TeacherGraduation = ci.Advert.Teacher.Graduation,
                    ImageUrl = ci.Advert.Teacher.User.Image.Url,
                    Description = ci.Advert.Description,
                    BranchName = ci.Advert.Branch.BranchName
                }).ToList()
            };


            return View(orderViewModel);
        }

        [NonAction]
        private async void SaveOrder(OrderViewModel orderViewModel, string userId)
        {
            Order order = new Order();
            order.OrderState = EnumOrderState.Unpaid;
            order.OrderType = EnumOrderType.CreditCard;
            order.OrderDate = DateTime.Now;
            order.FirstName = orderViewModel.FirstName;
            order.LastName = orderViewModel.LastName;
            order.NormalizedName = (orderViewModel.FirstName + orderViewModel.LastName).ToUpper();
            order.Phone = orderViewModel.Phone;
            order.Email = orderViewModel.Email;
            order.City = orderViewModel.City;
            order.Address = orderViewModel.City;
            order.UserId = userId;
            order.OrderItems = new List<Entity.Concrete.OrderItem>();
            foreach (var cartItem in orderViewModel.Cart.CartItems)
            {
                Entity.Concrete.OrderItem orderItem = new Entity.Concrete.OrderItem();
                orderItem.Price = cartItem.ItemPrice;
                orderItem.Amount = cartItem.Amount;
                orderItem.AdvertId = cartItem.AdvertId;
                order.OrderItems.Add(orderItem);
            }
            await _orderService.CreateAsync(order);
        }

        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            //luhn algoritması
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }


        private Payment PaymentProcess(OrderViewModel orderViewModel)
        {
            #region Payment Options Created
            Options options = new Options();
            options.ApiKey = "sandbox-ADv5KDZTeX26elqOwdkKvjtSZ2W6jV4z";
            options.SecretKey = "sandbox-4AgdWxxw82xXZCaZeQC6kmewpvU2WPrK";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            #endregion
            #region Create Payment Request
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                PaidPrice = Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = orderViewModel.Cart.CartId.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = orderViewModel.CardName,
                    CardNumber = orderViewModel.CardNumber,
                    ExpireMonth = orderViewModel.ExpirationMonth,
                    ExpireYear = orderViewModel.ExpirationYear,
                    Cvc = orderViewModel.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY999",
                    Name = orderViewModel.FirstName,
                    Surname = orderViewModel.LastName,
                    GsmNumber = orderViewModel.Phone,
                    Email = orderViewModel.Email,
                    IdentityNumber = "87955588899",
                    RegistrationAddress = orderViewModel.City,
                    Ip = "84.99.155.212",
                    City = orderViewModel.City,
                    Country = "Türkiye",
                    ZipCode = "34700"
                },
                ShippingAddress = new Address
                {
                    ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName,
                    City = orderViewModel.City,
                    Country = "Türkiye",
                    Description = orderViewModel.City
                },
                BillingAddress = new Address
                {
                    ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName,
                    City = orderViewModel.City,
                    Country = "Türkiye",
                    Description = orderViewModel.City
                }
            };
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach (var item in orderViewModel.Cart.CartItems)
            {
                basketItem = new BasketItem
                {
                    Id = item.CartItemId.ToString(),
                    Name = item.TeacherName.ToString(),
                    Category1 = "Ürün",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = Convert.ToInt32(item.ItemPrice * item.Amount).ToString()
                };
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;
            #endregion
            Payment payment = Payment.Create(request, options);
            return payment;
        }
    }
}
