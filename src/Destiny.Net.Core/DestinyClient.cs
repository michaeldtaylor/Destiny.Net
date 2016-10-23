using System;
using System.Collections.Generic;
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

            // https://www.bungie.net/platform/Destiny/SearchDestinyPlayer/2/Tyridan/
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

        public async Task<GroupSearchResponse> GroupSearch(string groupName)
        {
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            // https://www.bungie.net/platform/Group/Search/
            var apiPath = DestinyApiPaths.GroupSearchApiPath();

            var query = new GroupSearchQuery
            {
                Contents =
                {
                    SearchType = 0,
                    SearchValue = groupName
                },
                CreationDate = 0,
                SortBy = 0,
                ItemsPerPage = 10,
                CurrentPage = 1,
                MembershipType = 0,
                TagText = string.Empty,
                LocaleFilter = "en",
                GroupMemberCountFilter = 0
            };

            return await _destinyApi.Post<GroupSearchResponse>(apiPath, query);
        }

        public async Task<List<MemberResult>> GetMembersOfGroup(string groupId)
        {
            GroupMembersResponse response;

            var memberResults = new List<MemberResult>();
            var currentPage = 1;

            do
            {
                // https://www.bungie.net/Group/886149/MembersV3/
                var apiPath = DestinyApiPaths.GroupMembersApiPath(groupId, 50, currentPage);
                
                response = await _destinyApi.GetSimpleEnvelope<GroupMembersResponse>(apiPath);

                memberResults.AddRange(response.results);

                currentPage++;
            } while (response.hasMore);

            return memberResults;
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
