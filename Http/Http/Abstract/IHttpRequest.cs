using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public interface IHttpRequest
    {
        Task<IHttpResponse> Send();
    }
}
