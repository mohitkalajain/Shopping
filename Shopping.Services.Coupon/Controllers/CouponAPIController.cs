using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Services.Coupon.DataContext;
using Shopping.Services.CouponApi.Models.Dto;
using Shopping.Services.CouponApi.Repository.Interface;
namespace Shopping.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponAPIController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _couponService.Get();

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)] // Successful response
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status400BadRequest)] // Bad request error
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status404NotFound)] // Not found error
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status500InternalServerError)] // Internal server error
        public async Task<IActionResult> Get(int id)
        {

            if (id == 0)
                return BadRequest(new ResponseDto(string.Empty, false, "Value must be greater than 0", StatusCodes.Status400BadRequest));

            var result = await _couponService.Get(id);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
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
