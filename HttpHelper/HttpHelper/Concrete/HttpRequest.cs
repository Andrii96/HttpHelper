
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpHelper
{
    public class HttpRequest : IHttpRequest
    {
        #region Fields
        private RequestBuilder _request;
        #endregion

        #region Constructor
        public HttpRequest(RequestBuilder request)
        {
            _request = request ?? throw new NullReferenceException("Request parameter can not be null.");
        }
        #endregion

        #region Methods

        public async Task<IHttpResponse> Send()
        {
            var response = new HttpResponseMessage();

            using (var httpClient = new HttpClient())
            {
                switch (_request.MethodType)
                {
                    case MethodType.Get:
                        response = await httpClient.GetAsync(_request.Url);
                        break;
                    case MethodType.Post:
                        response = await httpClient.PostAsync(_request.Url, SerializeContent(_request.Content));
                        break;
                    case MethodType.Put:
                        response = await httpClient.PutAsync(_request.Url, SerializeContent(_request.Content));
                        break;
                    case MethodType.Delete:
                        response = await httpClient.DeleteAsync(_request.Url);
                        break;
                }
            }
            return new HttpResponse(response);
        }

        #endregion

        #region Helpers
        private StringContent SerializeContent(object content)
        {
            if (content == null)
            {
                return null;
            }
            var jsonContent = JsonConvert.SerializeObject(content);
            return new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json");
        }
        #endregion

    }
}
