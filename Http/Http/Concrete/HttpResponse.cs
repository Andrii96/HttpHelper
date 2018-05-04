
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public class HttpResponse : IHttpResponse
    {
        #region Fields
        private HttpResponseMessage _responseMessage;
        #endregion

        #region Constructor
        public HttpResponse(HttpResponseMessage response)
        {
            _responseMessage = response;
        }
        #endregion

        #region Properties

        public HttpStatusCode StatusCode => _responseMessage.StatusCode;

        public bool IsSuccess => _responseMessage.IsSuccessStatusCode;

        #endregion

        #region Methods

        public async Task<T> DeserializeContent<T>()
        {
            var stringResult = await _responseMessage.Content.ReadAsStringAsync();
            var deserializedResult = JsonConvert.DeserializeObject<T>(stringResult);
            return deserializedResult;
        }

        public async Task<string> GetErrorDescription()
        {
            return _responseMessage.IsSuccessStatusCode ? null : await _responseMessage.Content.ReadAsStringAsync();
        }

        #endregion

    }
}
