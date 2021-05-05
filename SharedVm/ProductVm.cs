using System;
using System.Collections.Generic;

namespace SharedVm
{
    public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageLocation { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CategoryId { get; set; }
        //public string Content { get; set; }
        public decimal AverageStar { get; set; }
        public List<RateVm> rateVms { get; set; }
        public bool isDelete { get; set; }

    }
}
