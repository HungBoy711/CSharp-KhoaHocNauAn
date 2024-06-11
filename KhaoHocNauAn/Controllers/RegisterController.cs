using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Utilities;

namespace KhoaHocNauAn.Controllers
{
	public class RegisterController : Controller
	{
		private DataContext _context;
		public RegisterController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Customer customer)
		{
			if (customer == null)
			{
				return NotFound();
			}
			var check = _context.Customers.Where(m => m.Email == customer.Email).FirstOrDefault();
			if (check != null)
			{
				Functions._MessageEmail = "Trùng Email!";
				return RedirectToAction("Index", "Register");
			}
			Functions._MessageEmail = string.Empty;
			customer.Password = Functions.MD5Password(customer.Password);
			_context.Add(customer);
			_context.SaveChanges();
			return RedirectToAction("Index", "Login");
		}
	}
}
