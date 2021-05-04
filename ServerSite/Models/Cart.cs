using System.Collections.Generic;

namespace ServerSite.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
