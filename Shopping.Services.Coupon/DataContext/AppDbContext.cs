using Microsoft.EntityFrameworkCore;
namespace Shopping.Services.Coupon.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon
            {
                CouponId=1,
                CouponCode="10OFF",
                DiscountAmount=10,
                MinAmount=20
            });
            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40
            });
            modelBuilder.Entity<Models.Coupon>().HasData(new Models.Coupon
            {
                CouponId = 3,
                CouponCode = "30OFF",
                DiscountAmount = 30,
                MinAmount = 60
            });
        }
    }
}
