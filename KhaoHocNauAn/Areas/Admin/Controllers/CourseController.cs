using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Areas.Admin.CheckPassAdmin;

namespace KhoaHocNauAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }
		public IActionResult Index(string SearchString)
		{
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login2");
            var cookingCourse = _context.CookingCourses.ToList();

			if (!String.IsNullOrEmpty(SearchString))
			{
				cookingCourse = cookingCourse
					.Where(c => c.CourseName!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
					.ToList();
			}

			return View(cookingCourse);
		}

		public IActionResult Create()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(CookingCourse c)
		{
            if(ModelState.IsValid)
            {
                _context.CookingCourses.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index","Course");
            }
			return View(c);
		}

		public IActionResult Edit(int? id)
		{
			CookingCourse? course = _context.CookingCourses.Where(c => c.CourseID == id).FirstOrDefault();
			return PartialView("_CourseEditPartialView",course);
		}

		[HttpPost]
		public IActionResult Edit(CookingCourse course)
		{
				_context.CookingCourses.Update(course);
				_context.SaveChanges();
				return RedirectToAction("Index");
			
		}
		public IActionResult Delete(int? id)
		{
			CookingCourse? course = _context.CookingCourses.Where(c => c.CourseID == id).FirstOrDefault();
			return PartialView("_CourseDeletePartialView", course);
		}

		[HttpPost]
		public IActionResult Delete(CookingCourse course)
		{
			_context.CookingCourses.Remove(course);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
