using System;
using System.Threading.Tasks;
using Destiny.Net.Core.Model;
using Destiny.Net.Core.Model.Responses;

namespace Destiny.Net.Core
{
    public class DestinyClient
    {
        readonly DestinyApi _destinyApi;

        public DestinyClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _destinyApi = new DestinyApi(apiKey);
        }

        // https://www.bungie.net/Platform/Destiny/Manifest/
        public async Task<ManifestResponse> GetManifest()
        {
            var apiPath = DestinyApiPaths.ManifestApiPath();

            return await _destinyApi.GetSimpleEnvelope<ManifestResponse>(apiPath);
        }

        public async Task<DestinyPlayerResponse> SearchDestinyPlayer(Platform platform, string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            // https://www.bungie.net/Platform/Destiny/SearchDestinyPlayer/2/Tyridan/
            var apiPath = DestinyApiPaths.SearchDestinyPlayerApiPath((int)platform, displayName);

            return await _destinyApi.GetSimpleCollectionEnvelope<DestinyPlayerResponse>(apiPath);
        }

        public async Task<AccountSummaryResponse> GetAccountSummary(Platform platform, string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var envelope = await SearchDestinyPlayer(Platform.PlayStation, displayName);

            if (envelope == null)
            {
                return null;
            }

            // https://www.bungie.net/platform/Destiny/2/Account/4611686018429501017/Summary/
            var apiPath = DestinyApiPaths.AccountSummaryApiPath((int)platform, envelope.MembershipId);

            return await _destinyApi.GetDataEnvelope<AccountSummaryResponse>(apiPath);
        }

        public async Task<BungieAccountResponse> GetBungieAccount(string displayName, Platform platform)
        {
            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            var envelope = await SearchDestinyPlayer(Platform.PlayStation, displayName);

            if (envelope == null)
            {
                return null;
            }

            // https://www.bungie.net/User/GetBungieAccount/Tyridan/2/
            var apiPath = DestinyApiPaths.BungieAccountApiPath(envelope.MembershipId, (int)platform);

            return await _destinyApi.GetSimpleEnvelope<BungieAccountResponse>(apiPath);
        }

        // TODO: This doesn't actually need an API key!
        public async Task<InventoryItem> GetInventoryItem(long id)
        {
            var apiPath = DestinyApiPaths.ManifestTypeApiPath(DestinyManifestResponse.Types.InventoryItem, id);
            var envelope = await _destinyApi.GetDataEnvelope<InventoryItemResponse>(apiPath);

            return envelope.InventoryItem;
        }
    }
}
