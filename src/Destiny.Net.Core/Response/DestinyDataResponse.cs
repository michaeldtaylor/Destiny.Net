using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core.Response
{
    public class DestinyDataResponse<T> where T : DestinyResponse
    {
        public T Data { get; set; }
    }
}