using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using KhoaHocNauAn.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Mvc;
using PagedList;


namespace KhoaHocNauAn.Controllers
{
    public class TeacherController : Controller
    {
        private DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listofTeacher = (from b in _context.Teachers
                              where (b.IsActive == true)
                              orderby b.TeacherID ascending
                              select b
                              ).ToList();
            return View(listofTeacher);
        }
		[Route("/Detail-Teachers-{slug}-{id:int}.html", Name = "DetailTeachers")]
		public IActionResult DetailTeachers(int? id)
		{
			if (!Functions.IsLogin())
				return RedirectToAction("Index", "Login");
			
			if (id == null)
			{
				return NotFound();
			}
			var teachers = _context.Teachers
				.FirstOrDefault(m => (m.TeacherID == id) && (m.IsActive == true));
			if (teachers == null)
			{
				return NotFound();
			}
			
			return View(teachers);
		}
	}
}
