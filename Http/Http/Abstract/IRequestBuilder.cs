using System;
using System.Collections.Generic;
using System.Text;

namespace HttpHelper
{
    public enum MethodType
    {
        Get, Post, Put, Delete, None
    }
    public interface IRequestBuilder
    {
        IRequestBuilder UseUrl(string url);
        IRequestBuilder UseMethod(MethodType methodType);
        IRequestBuilder RequestBody(object content);
        IHttpRequest Build();
    }
}
