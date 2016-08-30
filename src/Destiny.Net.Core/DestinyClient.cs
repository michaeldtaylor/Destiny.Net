using System.Threading.Tasks;
using Destiny.Net.Core.Model;
using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core
{
    public class DestinyClient
    {
        readonly string _apiKey;

        public DestinyClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        // https://www.bungie.net/Platform/Destiny/Manifest/
        public async Task<GetDestinyManifestResponse> GetDestinyManifest()
        {
            using (var api = new DestinyApi(_apiKey))
            {
                var apiPath = GetDestinyManifestResponse.BuildApiPath();

                return await api.GetSimpleEnvelope<GetDestinyManifestResponse>(apiPath);
            }
        }

        // https://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/2/Tyridan/
        public async Task<SearchDestinyPlayerResponse> SearchDestinyPlayer(Platform platform, string displayName)
        {
            using (var api = new DestinyApi(_apiKey))
            {
                var apiPath = SearchDestinyPlayerResponse.BuildApiPath((int)platform, displayName);

                return await api.GetSimpleCollectionEnvelope<SearchDestinyPlayerResponse>(apiPath);
            }
        }

        // https://www.bungie.net/platform/Destiny/2/Account/4611686018429501017/Summary/
        public async Task<GetAccountSummaryResponse> GetAccountSummary(Platform platform, string displayName)
        {
            using (var api = new DestinyApi(_apiKey))
            {
                var envelope = await SearchDestinyPlayer(Platform.PlayStation, displayName);

                if (envelope == null)
                {
                    return null;
                }

                var apiPath = GetAccountSummaryResponse.BuildApiPath((int)platform, envelope.MembershipId);

                return await api.GetDataEnvelope<GetAccountSummaryResponse>(apiPath);
            }
        }

        // TODO: This doesn't actually need an API key!
        public async Task<InventoryItem> GetInventoryItem(long id)
        {
            var apiPath = DestinyManifestResponse.BuildApiPath(DestinyManifestResponse.Types.InventoryItem, id);

            using (var api = new DestinyApi(_apiKey))
            {
                var envelope = await api.GetDataEnvelope<InventoryItemResponse>(apiPath);

                return envelope.InventoryItem;
            }
        }
    }
}
