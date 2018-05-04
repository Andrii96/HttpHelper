using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }
        bool IsSuccess { get; }
        Task<string> GetErrorDescription();
        Task<T> DeserializeContent<T>();
    }
}
