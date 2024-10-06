using Shopping.Services.CouponApi.Models.Dto;

namespace Shopping.Services.CouponApi.Repository.Interface
{
    public interface ICouponService
    {
        Task<ResponseDto> Get();
        Task<ResponseDto> Get(int Id);
    }
}
