using System;
using System.Collections.Generic;

namespace ServerSite.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal AverageStar { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public bool isDelete { get; set; }

    }
}
