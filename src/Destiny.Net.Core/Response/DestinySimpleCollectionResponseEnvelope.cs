using System.Collections.Generic;
using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core.Response
{
    public class DestinySimpleCollectionResponseEnvelope<T> : DestinyResponseEnvelope where T : DestinyResponse
    {
        public IEnumerable<T> Response { get; set; }
    }
}