namespace Api.Base.BaseResponse
{
    public partial class ApiResponse<T> : ApiResponse
    {
        public T Response { get; set; } = default;

        public ApiResponse(bool isSuccess) : base(isSuccess) 
        {

        }
        public ApiResponse(T data)
        {
            Success = true;
            Response = data;
            Message = "Success";
        }
        public ApiResponse(string message) : base(message) 
        {
                 
        }
    }

    public partial class ApiResponse 
    {
        public ApiResponse(bool isSuccess)
        {
            Success = isSuccess;      
            Message = isSuccess ? "Success" : "Error";
        }

        public ApiResponse(string message = null)
        {              
                Success = false;
                Message = message;       
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
