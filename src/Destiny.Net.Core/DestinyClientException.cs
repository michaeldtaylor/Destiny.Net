using System;
using System.Net;
using Destiny.Net.Core.Response;

namespace Destiny.Net.Core
{
    public class DestinyClientException : Exception
    {
        public DestinyClientException(Uri apiUri, HttpStatusCode statusCode) :
            base($"Destiny HTTP response status code {statusCode} occured when calling API URI '{apiUri.AbsolutePath}'")
        {
            ApiUri = apiUri;
            StatusCode = statusCode;
        }

        public DestinyClientException(Uri apiUri, HttpStatusCode statusCode, DestinyResponseEnvelope responseEnvelope) :
            base($"Destiny error code {responseEnvelope.ErrorCode} occured when calling API URI '{apiUri.AbsolutePath}': {responseEnvelope.Message}")
        {
            ApiUri = apiUri;
            StatusCode = statusCode;
            ResponseEnvelope = responseEnvelope;
        }

        public Uri ApiUri { get; }
        public HttpStatusCode StatusCode { get; }
        public DestinyResponseEnvelope ResponseEnvelope { get; }
    }
}