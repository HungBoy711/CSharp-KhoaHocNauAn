using Microsoft.AspNetCore.Mvc;
using  KhoaHocNauAn.Models;
using KhoaHocNauAn.Controllers;

namespace KhoaHocNauAn.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly ILogger<MenuViewComponent> _logger;
        private DataContext _context;
        public MenuViewComponent(ILogger<MenuViewComponent> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentPage = HttpContext.Request.Path;
            var currentUrl = currentPage.Value.Substring(1);

            ViewBag.CurrentUrl = currentUrl;

            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }

    }
}
