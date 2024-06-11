using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Utilities;

namespace KhoaHocNauAn.Controllers
{
    public class LoginController : Controller
    {
        private DataContext _context;
        public LoginController(DataContext context)
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

            string pw = Functions.MD5Password(customer.Password);
            var check = _context.Customers.Where(m => (m.Email == customer.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Họ và tên hoặc mật khẩu trống";
                return RedirectToAction("Index","Login");
            }
            
            Functions._Message = string.Empty;
            Functions._CustomerID = check.CustomerID;
			Functions._Phone = check.Phone;
			Functions._CustomerName = string.IsNullOrEmpty(check.CustomerName) ? string.Empty : check.CustomerName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "CookingCourse");
        }
    }
}
