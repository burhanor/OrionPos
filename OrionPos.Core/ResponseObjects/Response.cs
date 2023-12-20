using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.ResponseObjects
{
    public class Response:IResponse
    {
        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
     
    }
}
