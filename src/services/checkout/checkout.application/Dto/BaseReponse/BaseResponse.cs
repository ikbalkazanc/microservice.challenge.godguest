using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkout.application.Dto.BaseReponse
{
    public class BaseResponse<T> where T : class
    {
        public string Status { get; set; } = "success";
        public T Data { get; set; }
        public List<ErrorDto> Errors { get; set; }

        public BaseResponse<T> AddError(int code,string message)
        {
            Status = "error";
            Errors ??= new List<ErrorDto>();
            Errors.Add(new ErrorDto(){Code = code,Message = message });
            return this;
        }

    }
}
