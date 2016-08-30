namespace Destiny.Net.Core.Model
{
    public class InventoryItem
    {
        public long ItemHash { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Icon { get; set; }
        public string SecondaryIcon { get; set; }
        public string TierTypeName { get; set; }
        public int TierType { get; set; }
        public string ItemTypeName { get; set; }
        public int QualityLevel { get; set; }
        public int ItemType { get; set; }
        public int ItemSubType { get; set; }
        public int MaxStackSize { get; set; }
    }
}