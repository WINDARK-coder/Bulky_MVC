using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // here we create an object that retrieves all methods
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; // and pass it to this variable in constructor to then use it in all places of class
            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= _db.Categories.ToList(); // here we call it and get list of categories   
            return View(objCategoryList);
        }
    }
}
