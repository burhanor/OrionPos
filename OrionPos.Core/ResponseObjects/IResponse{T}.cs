using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.ResponseObjects
{
    public interface IResponse<T>:IResponse
    {

        T Data { get; set; }
        ICollection<AppValidationError> ValidationErrors { get; set; }
    }
}
