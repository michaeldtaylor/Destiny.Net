using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny.Net.Core.Model.Responses;
using Destiny.Net.Core.Response;
using Newtonsoft.Json;
using NLog;

namespace Destiny.Net.Core
{
    public class DestinyApi : IDisposable
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        const string DestinyApiEndpoint = "https://www.bungie.net/platform/Destiny";
        const string XApiKey = "X-API-Key";

        readonly HttpClient _client;

        public DestinyApi(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add(XApiKey, apiKey);
        }

        public async Task<T> GetSimpleEnvelope<T>(string apiPath) where T : DestinyResponse
        {
            var httpContent = await GetHttpContent(apiPath);
            var destinyResponseEnvelope = JsonConvert.DeserializeObject<DestinySimpleResponseEnvelope<T>>(httpContent);

            return destinyResponseEnvelope.Response;
        }

        public async Task<T> GetSimpleCollectionEnvelope<T>(string apiPath) where T : DestinyResponse
        {
            var httpContent = await GetHttpContent(apiPath);
            var destinyResponseEnvelope = JsonConvert.DeserializeObject<DestinySimpleCollectionResponseEnvelope<T>>(httpContent);

            return destinyResponseEnvelope.Response.SingleOrDefault();
        }

        public async Task<T> GetDataEnvelope<T>(string apiPath) where T : DestinyResponse
        {
            var httpContent = await GetHttpContent(apiPath);
            var destinyResponseEnvelope = JsonConvert.DeserializeObject<DestinyDataResponseEnvelope<T>>(httpContent);

            return destinyResponseEnvelope.Response.Data;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        async Task<string> GetHttpContent(string apiPath)
        {
            var apiUri = new Uri($"{DestinyApiEndpoint}/{apiPath}/");
            var httpResponse = await _client.GetAsync(apiUri);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var destinyResponseEnvelope = JsonConvert.DeserializeObject<DestinyResponseEnvelope>(responseContent);

            if (destinyResponseEnvelope.ErrorCode == DestinyErrorCodes.Ok)
            {
                return responseContent;
            }

            Logger.Error($"Destiny error code {destinyResponseEnvelope.ErrorCode} occured when calling API URI '{apiUri.AbsolutePath}': {destinyResponseEnvelope.Message}");

            throw new DestinyClientException(apiUri, destinyResponseEnvelope);
        }
    }
}