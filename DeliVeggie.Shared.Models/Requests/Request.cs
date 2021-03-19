using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Shared.Models.Requests
{
    public class Request<T> : IRequest
    {
        public T Data { get; set; }
    }
}
