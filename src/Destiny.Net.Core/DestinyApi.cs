using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Destiny.Net.Core.Model.Responses;
using Destiny.Net.Core.Response;
using Newtonsoft.Json;

namespace Destiny.Net.Core
{
    public class DestinyApi
    {
        const string XApiKey = "X-API-Key";

        static readonly Uri BungiePlatformEndpoint = new Uri("https://www.bungie.net/platform/");
        static readonly HttpClient Client = new HttpClient();

        readonly string _apiKey;

        public DestinyApi(string apiKey)
        {
            _apiKey = apiKey;
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

        async Task<string> GetHttpContent(string apiPath)
        {
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add(XApiKey, _apiKey);

            var apiUri = new Uri(BungiePlatformEndpoint, apiPath);
            var httpResponse = await Client.GetAsync(apiUri);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new DestinyClientException(apiUri, httpResponse.StatusCode);
            }

            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var destinyResponseEnvelope = JsonConvert.DeserializeObject<DestinyResponseEnvelope>(responseContent);

            if (destinyResponseEnvelope.ErrorCode == DestinyErrorCodes.Ok)
            {
                return responseContent;
            }

            throw new DestinyClientException(apiUri, httpResponse.StatusCode, destinyResponseEnvelope);
        }
    }
}