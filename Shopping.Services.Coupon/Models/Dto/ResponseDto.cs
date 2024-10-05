namespace Shopping.Services.CouponApi.Models.Dto
{
    public class ResponseDto
    {
        public dynamic Result { get; set; }=string.Empty;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }=string.Empty; 
        public int   StatusCode { get; set; }
    }
}
