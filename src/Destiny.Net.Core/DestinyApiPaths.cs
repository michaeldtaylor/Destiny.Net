namespace Destiny.Net.Core
{
    public static class DestinyApiPaths
    {
        public static string BungieAccountApiPath(string membershipId, int membershipType)
        {
            return $"User/GetBungieAccount/{membershipId}/{membershipType}/";
        }

        public static string AccountSummaryApiPath(int membershipType, string membershipId)
        {
            return $"Destiny/{membershipType}/Account/{membershipId}/Summary/";
        }

        public static string SearchDestinyPlayerApiPath(int membershipType, string displayName)
        {
            return $"Destiny/SearchDestinyPlayer/{membershipType}/{displayName}/";
        }

        public static string GroupSearchApiPath()
        {
            return "Group/Search/";
        }

        public static string GroupMembersApiPath(string groupId, int itemsPerPage = 10, int currentPage = 1)
        {
            return $"Group/{groupId}/MembersV3/?itemsPerPage={itemsPerPage}&currentPage={currentPage}&memberType=-1&sort=0";
        }

        public static string ManifestApiPath()
        {
            return "Destiny/Manifest/";
        }
        
        public static string ManifestTypeApiPath(string type, long id)
        {
            return $"Destiny/Manifest/{type}/{id}/";
        }
    }
}