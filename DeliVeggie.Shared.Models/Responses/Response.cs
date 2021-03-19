using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Shared.Models.Responses
{
    public class Response<T> : IResponse
    {
        public T Data { get; set; }
    }
}
