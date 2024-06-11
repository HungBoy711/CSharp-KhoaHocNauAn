using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KhoaHocNauAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private DataContext _context;
        public MenuController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Menu = _context.Menus.ToList();
            return View(Menu);
        }
	}
}
