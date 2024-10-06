namespace Shopping.Services.CouponApi.Models.Dto
{
    public class ResponseDto
    {
        public dynamic? Result { get; set; }=string.Empty;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }=string.Empty; 
        public int   StatusCode { get; set; }
        public ResponseDto(dynamic result, bool isSuccess, string message, int statusCode)
        {
            Result = result??string.Empty;
            IsSuccess = isSuccess;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
