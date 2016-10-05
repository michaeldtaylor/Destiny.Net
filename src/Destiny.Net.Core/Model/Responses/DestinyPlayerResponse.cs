namespace Destiny.Net.Core.Model.Responses
{
    public class DestinyPlayerResponse : DestinyResponse
    {
        public string IconPath { get; set; }
        public int MembershipType { get; set; }
        public string MembershipId { get; set; }
        public string DisplayName { get; set; }
    }
}