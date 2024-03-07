using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString()) // it is the custom validation
            //{
            //    ModelState.AddModelError("name","The Display Order cannot exactly match the Name"); // and that is its custom error message(first param is where will be this error displayed, what field)
            //}
            //if (obj.Name != null && obj.Name.ToLower() == "test") 
            //{
            //    ModelState.AddModelError("", "Test is an invalid value"); // if you dont give 1 param it will be show only in summary all errors
            //}
            if (ModelState.IsValid)
            {
            _db.Categories.Add(obj); // here you add obj(data that comes from post form)
            _db.SaveChanges(); // and here you save the changes that added to that object
            TempData["success"] = "Category created successfully";// this is for giving a notification of an action(create,update,delete) and it will be shown only once
            return RedirectToAction("Index","Category");// you redirect here to the index after creating category(then to reload and show new category also). Second param is defines the controllers name
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null ||id == 0)
            {
                return NotFound(); // in case if there will be wrong id 
            }
            Category? categoryFromDb = _db.Categories.Find(id);// only works for primary key
            Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);// retrieves first element that satisfies specified condition (otherwise null)
            Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); // if you have more conditions for retrieving data

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]  
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);// here we pass object from view to update it
                _db.SaveChanges(); // and here you save the changes that added to that object
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");// you redirect here to the index after creating category(then to reload and show new category also). Second param is defines the controllers name
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // in case if there will be wrong id 
            }
            Category? categoryFromDb = _db.Categories.Find(id);// only works for primary key
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")] // second param for defining new name of action
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);// we find data of given id
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);// here we pass object that we found and remove it
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
