using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace KhoaHocNauAn.Controllers
{
    public class BlogController : Controller
    {
        private DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listofBlog = (from b in _context.Blogs
                              where (b.IsActive == true)
                              orderby b.BlogID ascending
                              select b
                              ).ToList();
            return View(listofBlog);
        }
    }
}
