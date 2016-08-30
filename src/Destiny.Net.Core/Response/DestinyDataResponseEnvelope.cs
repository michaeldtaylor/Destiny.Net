using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core.Response
{
    public class DestinyDataResponseEnvelope<T> : DestinyResponseEnvelope where T : DestinyResponse
    {
        public DestinyDataResponse<T> Response { get; set; }
    }
}