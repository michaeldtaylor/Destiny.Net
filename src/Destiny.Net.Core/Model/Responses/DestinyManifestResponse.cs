namespace Destiny.Net.Core.Model.Responses
{
    public abstract class DestinyManifestResponse : DestinyResponse
    {
        public static class Types
        {
            public const string InventoryItem = "InventoryItem";
        };

        public int RequestedId { get; set; }
    }
}