using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerSite.Models;

namespace ServerSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Phone",
                    Description = "Phone Description"
                },
                new Category
                {
                    Id = 2,
                    Name = "Tablet",
                    Description = "Tablet Description"
                },
                new Category
                {
                    Id = 3,
                    Name = "Laptop",
                    Description = "Laptop Description"
                }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Samsung Galaxy A32",
                    Description = "Samsung Galaxy A32 4G là chiếc điện thoại thuộc phân khúc tầm trung nhưng sở hữu nhiều ưu điểm vượt " +
                    "trội về màn hình lớn sắc nét, bộ bốn camera 64 MP cùng vi xử lý hiệu năng cao và được bán ra với mức giá vô cùng " +
                    "tốt.",

                    CategoryId = 1,
                    Inventory = 100,
                    Id = 1,
                    Price = 6690000

                },
                new Product
                {
                    Name = "iPhone 12 64GB",
                    Description = "Trong những tháng cuối năm 2020 Apple đã chính thức giới thiệu đến người dùng cũng như iFan thế hệ" +
                    " iPhone 12 series mới với hàng loạt tính năng bức phá, thiết kế được lột xác hoàn toàn, hiệu năng đầy mạnh mẽ và " +
                    "một trong số đó chính là iPhone 12 64GB.",

                    CategoryId = 1,
                    Inventory = 100,
                    Id = 2,
                    Price = 21990000

                },
                new Product
                {
                    Name = "Xiaomi Redmi Note 10",
                    Description = "Xiaomi đã trình làng chiếc điện thoại mang tên gọi là Xiaomi Redmi Note 10 với điểm nhấn chính là " +
                    "cụm 4 camera 48 MP, chip rồng Snapdragon 678 mạnh mẽ cùng nhiều nâng cấp như dung lượng pin 5.000 mAh và hỗ trợ " +
                    "sạc nhanh 33 W tiện lợi.",

                    CategoryId = 1,
                    Inventory = 100,
                    Id = 3,
                    Price = 5370000
                },
                new Product
                {
                    Name = "Huawei MatePad T10s",
                    Description = "Chiếc máy tính bảng giá rẻ đáng mong chờ của Huawei, Huawei MatePad T10s cuối cùng cũng đã chính" +
                    " thức ra mắt. Với vi xử lý 8 nhân mở ra một thế giới giải trí mượt mà, sống động từng khoảnh khắc với màn hình" +
                    " cực lớn, hé lộ một chiếc máy tính bảng tốt trong tầm giá mà bất kỳ ai cũng đều yêu thích.",

                    CategoryId = 2,
                    Inventory = 100,
                    Id = 4,
                    Price = 5290000
                },
                new Product
                {
                    Name = "Samsung Galaxy Tab A7",
                    Description = "Samsung Galaxy Tab A7 (2020) là một chiếc máy tính bảng có thiết kế đẹp, cấu hình khá, nhiều tính" +
                    " năng tiện ích, một công cụ đắc lực hỗ trợ bạn trong công việc cũng như trong học tập hay giải trí.",

                    CategoryId = 2,
                    Inventory = 100,
                    Id = 5,
                    Price = 6390000
                },
                new Product
                {
                    Name = "Lenovo Tab M10",
                    Description = "Từ việc sử dụng các thiết bị điện tử đa dạng của các gia đình hiện nay, Lenovo đã nắm bắt được nhu " +
                    "cầu thiết yếu này và cho ra mắt chiếc máy tính bảng Lenovo Tab M10 - FHD Plus với những tính năng tiện ích ấn " +
                    "tượng, “khoác chiếc áo” của thời đại và có mức giá siêu ưu đãi.",

                    CategoryId = 2,
                    Inventory = 100,
                    Id = 6,
                    Price = 5190000
                },
                new Product
                {
                    Name = "Lenovo IdeaPad S340",
                    Description = "Lenovo IdeaPad S340 14IIL (81VV003VVN) sở hữu cấu hình khá, hiệu năng ổn định và thiết kế tinh tế" +
                    " đẹp mắt. Đây sẽ là chiếc laptop văn phòng phù hợp với đối tượng sinh viên, dân văn phòng thường xuyên xử lý các" +
                    " tác vụ văn phòng, học tập và chỉnh sửa hình ảnh cơ bản.",

                    CategoryId = 3,
                    Inventory = 100,
                    Id = 7,
                    Price = 13990000
                },
                new Product
                {
                    Name = "Lenovo IdeaPad Flex 5",
                    Description = "Với bộ xử lý Intel Core i3 thế hệ thứ 10 tiên tiến cũng như các tùy chọn ổ cứng siêu nhanh" +
                    ", lưu trữ rộng lớn, Lenovo IdeaPad Flex 5 14IIL05 i3 chắc chắn là một lựa chọn tuyệt vời để bạn sử dụng hàng ngày.",

                    CategoryId = 3,
                    Inventory = 100,
                    Id = 8,
                    Price = 16490000
                },
                new Product
                {
                    Name = "Lenovo ThinkBook 15IIL",
                    Description = "Laptop Lenovo ThinkBook 15IIL i3 (20SM00D9VN) sở hữu thiết kế từ kim loại toát lên vẻ sang trọng, " +
                    "sắc sảo, cấu hình lí tưởng cho học tập, trình duyệt web khi trang bị bộ vi xử lý Intel thế hệ thứ 10 mới và ổ cứng" +
                    " SSD cực nhanh",

                    CategoryId = 3,
                    Inventory = 100,
                    Id = 9,
                    Price = 11690000
                }

                );
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    ImagePath = "/images/Phone/p1.png",
                    ProductId = 1
                },
                new Image
                {
                    Id = 10,
                    ImagePath = "/images/Phone/p1_1.png",
                    ProductId = 1
                },
                new Image
                {
                    Id = 11,
                    ImagePath = "/images/Phone/p1_2.png",
                    ProductId = 1
                },
                new Image
                {
                    Id = 12,
                    ImagePath = "/images/Phone/p1_3.png",
                    ProductId = 1
                },
                new Image
                {
                    Id = 13,
                    ImagePath = "/images/Phone/p1_4.png",
                    ProductId = 1
                },
                new Image
                {
                    Id = 2,
                    ImagePath = "/images/Phone/p2.png",
                    ProductId = 2
                },
                new Image
                {
                    Id = 14,
                    ImagePath = "/images/Phone/p2_1.png",
                    ProductId = 2
                },
                new Image
                {
                    Id = 15,
                    ImagePath = "/images/Phone/p2_2.png",
                    ProductId = 2
                },
                new Image
                {
                    Id = 16,
                    ImagePath = "/images/Phone/p2_3.png",
                    ProductId = 2
                },
                new Image
                {
                    Id = 3,
                    ImagePath = "/images/Phone/p3.png",
                    ProductId = 3
                },
                new Image
                {
                    Id = 17,
                    ImagePath = "/images/Phone/p3_1.png",
                    ProductId = 3
                },
                new Image
                {
                    Id = 18,
                    ImagePath = "/images/Phone/p3_2.png",
                    ProductId = 3
                },
                new Image
                {
                    Id = 19,
                    ImagePath = "/images/Phone/p3_3.png",
                    ProductId = 3
                },
                new Image
                {
                    Id = 4,
                    ImagePath = "/images/Tablet/tl1.png",
                    ProductId = 4
                },
                new Image
                {
                    Id = 20,
                    ImagePath = "/images/Tablet/tl1_1.png",
                    ProductId = 4
                },
                 new Image
                 {
                     Id = 21,
                     ImagePath = "/images/Tablet/tl1_2.png",
                     ProductId = 4
                 },
                  new Image
                  {
                      Id = 22,
                      ImagePath = "/images/Tablet/tl1_3.png",
                      ProductId = 4
                  },
                new Image
                {
                    Id = 5,
                    ImagePath = "/images/Tablet/tl2.png",
                    ProductId = 5
                },
                new Image
                {
                    Id = 23,
                    ImagePath = "/images/Tablet/tl2_1.png",
                    ProductId = 5
                },
                new Image
                {
                    Id = 24,
                    ImagePath = "/images/Tablet/tl2_2.png",
                    ProductId = 5
                },
                new Image
                {
                    Id = 25,
                    ImagePath = "/images/Tablet/tl2_3.png",
                    ProductId = 5
                },
                new Image
                {
                    Id = 6,
                    ImagePath = "/images/Tablet/tl3.png",
                    ProductId = 6
                },
                new Image
                {
                    Id = 26,
                    ImagePath = "/images/Tablet/tl3_1.png",
                    ProductId = 6
                },
                new Image
                {
                    Id = 27,
                    ImagePath = "/images/Tablet/tl3_2.png",
                    ProductId = 6
                },
                new Image
                {
                    Id = 28,
                    ImagePath = "/images/Tablet/tl3_3.png",
                    ProductId = 6
                },
                new Image
                {
                    Id = 7,
                    ImagePath = "/images/Laptop/lt1.png",
                    ProductId = 7

                },
                new Image
                {
                    Id = 29,
                    ImagePath = "/images/Laptop/lt1_1.png",
                    ProductId = 7

                },
                new Image
                {
                    Id = 30,
                    ImagePath = "/images/Laptop/lt1_2.png",
                    ProductId = 7

                },
                new Image
                {
                    Id = 31,
                    ImagePath = "/images/Laptop/lt1_3.png",
                    ProductId = 7

                },
                new Image
                {
                    Id = 8,
                    ImagePath = "/images/Laptop/lt2.png",
                    ProductId = 8

                },
                new Image
                {
                    Id = 32,
                    ImagePath = "/images/Laptop/lt2_1.png",
                    ProductId = 8

                },
                new Image
                {
                    Id = 33,
                    ImagePath = "/images/Laptop/lt2_2.png",
                    ProductId = 8

                },
                new Image
                {
                    Id = 34,
                    ImagePath = "/images/Laptop/lt2_3.png",
                    ProductId = 8

                },
                new Image
                {
                    Id = 9,
                    ImagePath = "/images/Laptop/lt3.png",
                    ProductId = 9

                },
                new Image
                {
                    Id = 35,
                    ImagePath = "/images/Laptop/lt3_1.png",
                    ProductId = 9

                },
                new Image
                {
                    Id = 36,
                    ImagePath = "/images/Laptop/lt3_2.png",
                    ProductId = 9

                },
                new Image
                {
                    Id = 37,
                    ImagePath = "/images/Laptop/lt3_3.png",
                    ProductId = 9

                }
                );
            modelBuilder.Entity<Banner>().HasData(
                new Banner
                {
                    ImagePath = "/images/Banner/bn1.png",
                    Id = 1,
                    ProductID = 1
                },
                new Banner
                {
                    ImagePath = "/images/Banner/bn2.png",
                    Id = 2,
                    ProductID = 2
                },
                new Banner
                {
                    ImagePath = "/images/Banner/bn3.png",
                    Id = 3,
                    ProductID = 3
                }
                );
        }
    }
}
