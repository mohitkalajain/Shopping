using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Services.Coupon.DataContext;
using Shopping.Services.CouponApi.Models.Dto;
namespace Shopping.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        public CouponAPIController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var result = await _context.Coupons.ToListAsync();
                _response.Result = result;
                _response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.ToString();
                _response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return _response;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var result = await _context.Coupons.FirstOrDefaultAsync(x => x.CouponId == id);
                _response.Result = result;
                _response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.ToString();
                _response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            return _response;
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
