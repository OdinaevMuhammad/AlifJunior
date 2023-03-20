using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Domain.Wrapper
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Response(T data)
        {
            Data = data;
            StatusCode = 200;
        }
        public Response(HttpStatusCode statusCode, string message)
        {
            StatusCode = (int)statusCode;
            Message = message;
        }
        public Response(HttpStatusCode statusCode, List<string> errors)
        {
            StatusCode = (int)statusCode;
            Errors = errors;
        }
    }
}