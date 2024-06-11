using KhoaHocNauAn.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoaHocNauAn.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CookingCourse> CookingCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<View_Detail_CookingCourse> DetailCourses { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<View_Registration> Registrations { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

	}
}