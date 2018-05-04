using System;


namespace HttpHelper
{
    public class RequestBuilder : IRequestBuilder
    {
        #region Properties
        public string Url { get; private set; }
        public MethodType MethodType { get; private set; }
        public object Content { get; private set; }
        #endregion

        #region Constructor
        private RequestBuilder()
        {
            MethodType = MethodType.None;
        }
        #endregion

        #region Methods

        public static IRequestBuilder CreateRequest()
        {
            return new RequestBuilder();
        }

        public IRequestBuilder UseMethod(MethodType methodType)
        {
            MethodType = methodType;
            return this;
        }

        public IRequestBuilder UseUrl(string url)
        {
            Url = url;
            return this;
        }

        public IRequestBuilder RequestBody(object content)
        {
            Content = content;
            return this;
        }

        public IHttpRequest Build()
        {
            if (MethodType == MethodType.None || string.IsNullOrEmpty(Url))
            {
                throw new InvalidOperationException("Url can not be null or empty and method type should be selected.");
            }

            return new HttpRequest(this);
        }

        #endregion

    }
}
