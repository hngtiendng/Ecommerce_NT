using System.ComponentModel.DataAnnotations.Schema;

namespace ServerSite.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public virtual Product Product { get; set; }
    }
}
