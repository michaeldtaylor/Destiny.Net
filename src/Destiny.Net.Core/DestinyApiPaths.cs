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