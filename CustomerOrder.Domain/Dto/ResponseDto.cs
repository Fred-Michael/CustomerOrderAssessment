using System.Collections.Generic;

namespace CustomerOrder.Domain.Dto
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public T Data { get; set; }
        public Dictionary<string, string> Errors { get; set; } 
    }
}
