namespace Destiny.Net.Core.Model.Responses
{
    public abstract class DestinyManifestResponse : DestinyResponse
    {
        public static class Types
        {
            public const string InventoryItem = "InventoryItem";
        };

        public override string Id => RequestedId.ToString();
        public int RequestedId { get; set; }

        public static string BuildApiPath(string type, long id)
        {
            return $"Manifest/{type}/{id}";
        }
    }
}