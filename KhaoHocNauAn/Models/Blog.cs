using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KhoaHocNauAn.Models
{
    [Table("Blog")]
    public class Blog
    {
        public int BlogID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Hot { get; set; }
        public bool? IsActive { get; set;}
        public int BlogOrder { get; set;}
        public int MenuID { get; set; }
    }
}
