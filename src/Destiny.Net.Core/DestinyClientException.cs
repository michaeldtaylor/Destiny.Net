using System;
using Destiny.Net.Core.Response;

namespace Destiny.Net.Core
{
    public class DestinyClientException : Exception
    {
        public DestinyClientException(Uri apiUri, DestinyResponseEnvelope responseEnvelope) :
            base($"Destiny error code {responseEnvelope.ErrorCode} occured when calling API URI '{apiUri.AbsolutePath}': {responseEnvelope.Message}")
        {
            ApiUri = apiUri;
            ResponseEnvelope = responseEnvelope;
        }

        public Uri ApiUri { get; }
        public DestinyResponseEnvelope ResponseEnvelope { get; }
    }
}