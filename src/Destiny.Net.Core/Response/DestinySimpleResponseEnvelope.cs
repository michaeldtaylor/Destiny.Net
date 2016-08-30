using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core.Response
{
    public class DestinySimpleResponseEnvelope<T> : DestinyResponseEnvelope where T : DestinyResponse
    {
        public T Response { get; set; }
    }
}