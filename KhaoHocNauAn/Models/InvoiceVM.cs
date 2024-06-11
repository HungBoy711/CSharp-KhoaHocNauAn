using Microsoft.AspNetCore.Mvc;

namespace KhoaHocNauAn.ViewModels
{
	public class InvoiceVM 
	{
		public string? CustomerName { get; set; }
		public int Phone { get; set; }
		public string? Email { get; set; }
		public string? Description { get; set; }
	}
}
