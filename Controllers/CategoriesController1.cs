using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using proj1.Data;
using proj1.Models;
using System.Diagnostics.Eventing.Reader;

namespace proj1.Controllers
{
    public class CategoriesController : Controller
    {
       ApplicationDbContext context = new ApplicationDbContext();
       public ViewResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Category());

        }
        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid) { 
            context.Categories.Add(request);
            context.SaveChanges();
            var categories = context.Categories.ToList();
            return RedirectToAction("Index"); }
            else
            {
                return View(request);
            }
        }
  
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return View("NotFound");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
          
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           var category=context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category request)
        {
            if (ModelState.IsValid)
            {
                var nameExists = context.Categories.Any(c => c.Name == request.Name && c.Id!= request.Id);
                if (!nameExists)
                {
                    context.Categories.Update(request);
                    context.SaveChanges();
                    var categories = context.Categories.ToList();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "category name is exists");
                    return View( request);
                }
            }
            else
            {
                    return View("Edit", request);
            }
        }



    }
}
