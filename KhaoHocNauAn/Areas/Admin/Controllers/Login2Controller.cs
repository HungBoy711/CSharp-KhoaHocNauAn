using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhoaHocNauAn.Areas.Admin.Models;
using KhoaHocNauAn.Areas.Admin.CheckPassAdmin;

namespace KhoaHocNauAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Login2Controller  : Controller
    {
        private DataContext _context;
        public Login2Controller (DataContext context)
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

            string pw = Functions.MD5Password(adminUser.Password);
            var check = _context.AdminUsers.Where(m => (m.Email == adminUser.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Họ và tên hoặc mật khẩu trống";
                return RedirectToAction("Index","Login2");
            }
            
            Functions._Message = string.Empty;
            Functions._UserID = check.UserID;
			Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}
