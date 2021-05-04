namespace SharedVm
{
    public class OrderDetailVm
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; }

    }
}
