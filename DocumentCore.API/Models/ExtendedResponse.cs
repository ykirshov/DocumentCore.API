namespace DocumentCore.API.Models
{
    public class ExtendedResponse<T> : SimpleResponse
    {
        public T Response { get; set; }
    }
}