using Azure;
using Microsoft.EntityFrameworkCore;
using Shopping.Services.Coupon.DataContext;
using Shopping.Services.CouponApi.Models.Dto;
using Shopping.Services.CouponApi.Repository.Interface;

namespace Shopping.Services.CouponApi.Repository.Implementation
{
    public class CouponService : ICouponService
    {
        private readonly AppDbContext _context;
        public CouponService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseDto> Get()
        {
            try
            {
                var result = await _context.Coupons.ToListAsync();
                return new ResponseDto(result, true, "Success", StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ResponseDto(string.Empty, false, "Error", StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ResponseDto> Get(int Id)
        {
            try
            {
                var result = await _context.Coupons
                                            .FirstOrDefaultAsync(x => x.CouponId == Id);

                if (result is not null)
                    return new ResponseDto(result, true, "Success", StatusCodes.Status200OK);
                else
                    return new ResponseDto(result, true, "No Record Found", StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ResponseDto(string.Empty, false, "Error", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
