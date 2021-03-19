namespace DeliVeggie.Shared.Models.Responses
{
    public class Response<T> : IResponse
    {
        public T Data { get; set; }
    }
}