using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Areas.Admin.Models;
using KhoaHocNauAn.Areas.Admin.CheckPassAdmin;

namespace KhoaHocNauAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Register2Controller : Controller
	{
		private DataContext _context;
		public Register2Controller(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(AdminUser adminUser)
		{
			if (adminUser == null)
			{
				return NotFound();
			}
			var check = _context.AdminUsers.Where(m => m.Email == adminUser.Email).FirstOrDefault();
			if (check != null)
			{
				Functions._MessageEmail = "Trùng Email!";
				return RedirectToAction("Index", "Register");
			}
			Functions._MessageEmail = string.Empty;
			adminUser.Password = Functions.MD5Password(adminUser.Password);
			_context.Add(adminUser);
			_context.SaveChanges();
			return RedirectToAction("Index", "Login2");
		}
	}
}
