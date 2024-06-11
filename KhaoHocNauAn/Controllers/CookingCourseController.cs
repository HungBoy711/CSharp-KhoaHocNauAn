using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Utilities;

namespace KhoaHocNauAn.Controllers
{
    public class CookingCourseController : Controller
    {
        public DataContext _context;
        public CookingCourseController(DataContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var cookingCourse = _context.DetailCourses.ToList();
            var categories = _context.Categories.ToList();

            var viewModel = new CategoryCourse
            {
                DetailCourses = cookingCourse,
                Categories = categories
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetFilteredCourses(int[] CategoryIDS)
        {
            var cookingCourse = _context.DetailCourses
                .Where(c => CategoryIDS.Contains(c.CategoryID))
                .ToList();
            return PartialView("_CourseList", cookingCourse);
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var cookingCourse = _context.DetailCourses
                .ToList();
            return PartialView("_CourseList", cookingCourse);
        }

        [Route("/Detail-Courses-{slug}-{id:int}.html", Name = "Details")]
        public IActionResult Details(int? id)
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }
			var cookingCourse = _context.DetailCourses
                .FirstOrDefault(m => (m.CourseID == id) && (m.IsActive == true));
            if (cookingCourse == null)
            {
                return NotFound();
            }
			return View(cookingCourse);
        }


	}
}
