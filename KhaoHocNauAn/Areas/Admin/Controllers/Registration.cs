using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KhoaHocNauAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistrationController : Controller
    {
        private DataContext _context;
        public RegistrationController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var resistration = _context.Registrations.OrderByDescending(r => r.InvoiceDetailID).ToList();
            return View(resistration);
        }
	}
}
