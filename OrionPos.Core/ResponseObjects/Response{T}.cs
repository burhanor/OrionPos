using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.ResponseObjects
{
    public class Response<T>:Response,IResponse<T>
    {
        public Response(string message,ResponseType responseType):base(message,responseType)
        {
            
        }
        public Response(string message,ResponseType responseType,T data):this(message,responseType)
        {
            Data = data;
        }
        public Response(string message, T data,ICollection<AppValidationError> validationErrors):this(message,ResponseType.ValidationError,data)
        {
            ValidationErrors = validationErrors;
        }
        public  T Data { get; set; }
        public ICollection<AppValidationError> ValidationErrors { get; set; }

    }
}
