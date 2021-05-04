using System.Collections.Generic;

namespace ServerSite.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public string Description { get; set; }
        public bool isDelete { get; set; }

    }
}
