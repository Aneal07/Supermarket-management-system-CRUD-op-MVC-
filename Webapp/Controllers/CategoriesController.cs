using Microsoft.AspNetCore.Mvc;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRespository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            var category = CategoriesRespository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
           
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid) 
            {
                CategoriesRespository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category) 
        {
            if(ModelState.IsValid)
            {
                CategoriesRespository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
