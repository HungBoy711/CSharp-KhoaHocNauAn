using KhoaHocNauAn.Components;
using KhoaHocNauAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KhoaHocNauAn.Helpers;
using Microsoft.AspNetCore.Authorization;
using KhoaHocNauAn.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KhoaHocNauAn.Controllers
{
	public class CartController : Controller
	{
		private DataContext _context;
		public CartController(DataContext context)
		{
			_context = context;
		}

		const string CART_KEY = "MYCART";
		public List<Cart> Cart => HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();
		
		public IActionResult Index()
		{
            return View(Cart);
		}
		public IActionResult AddToCart(int id)
		{
            
            var cart = Cart;
			var item = cart.SingleOrDefault(c => c.CourseID == id);
			DateTime datenow = DateTime.Now;
			DateTime deadline = _context.DetailCourses
				.Where(d => (d.Deadline != null) && (d.CourseID == id))
				.Select(d => d.Deadline ?? DateTime.MinValue)
				.FirstOrDefault();
			int result = DateTime.Compare(deadline, datenow);

			if (result < 0)
			{
				return RedirectToAction("Failed", "Cart");
			}
			else
			{
				if (item == null)
				{
					var course = _context.DetailCourses.SingleOrDefault(c => c.CourseID == id);
					if (course == null)
					{
						return Redirect("/404");
					}
					item = new Cart
					{
						CourseID = course.CourseID,
						CourseName = course.CourseName,
						Images = course.Images,
						Price = course.Price
					};
					cart.Add(item);
				}
				HttpContext.Session.Set(CART_KEY, cart);
				return RedirectToAction("Index");
			}			
		}
		public IActionResult RemoveCart(int id)
		{
			var cart = Cart;
			var item = cart.SingleOrDefault(c => c.CourseID == id);
			if(item != null)
			{
				cart.Remove(item);
				HttpContext.Session.Set(CART_KEY, cart);
			}
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Checkout()
		{
			if (Cart.Count == 0)
			{
				return Redirect("/");
			}
			return View(Cart);
		}
		[HttpPost]
		public IActionResult Checkout(Invoice model)
		{
			if (ModelState.IsValid)
			{
				var invoice = new Invoice
				{
					CustomerID = model.CustomerID,
					CustomerName = model.CustomerName,
					Phone = model.Phone,
					Email = model.Email,
					Description = model.Description
				};

				_context.Database.BeginTransaction();
				try
				{
					_context.Database.CommitTransaction();
					_context.Add(invoice);
					_context.SaveChanges();

					var invoicedetails = new List<InvoiceDetail>();
					foreach (var item in Cart)
					{
						invoicedetails.Add(new InvoiceDetail
						{
							InvoiceID = invoice.InvoiceID,
							CourseID = item.CourseID,
							Price = item.Price,
							CourseName = item.CourseName
						});
					}
					_context.AddRange(invoicedetails);
					_context.SaveChanges();
					return RedirectToAction("Success","Cart");
				}
				catch
				{
					_context.Database.RollbackTransaction();
				}
			}
			return View(Cart);
		}
		public IActionResult Success()
		{	
			return View();
		}
		public IActionResult Failed()
		{
			return View();
		}
	}
}
