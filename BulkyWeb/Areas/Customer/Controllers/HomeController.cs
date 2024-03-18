using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork ;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() // returns the view of the same name as action (default)
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(productList); // but you can write here the name of view that will return
        }

        public IActionResult Details(int productId) // returns the view of the same name as action (default)
        {
            Product product = _unitOfWork.Product.Get(u=>u.Id== productId, includeProperties: "Category");
            return View(product); // but you can write here the name of view that will return
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
