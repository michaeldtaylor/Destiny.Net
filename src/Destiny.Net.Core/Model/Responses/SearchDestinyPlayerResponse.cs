namespace Destiny.Net.Core.Model.Responses
{
    public class SearchDestinyPlayerResponse : DestinyResponse
    {
        public override string Id => MembershipId;
        public string IconPath { get; set; }
        public int MembershipType { get; set; }
        public string MembershipId { get; set; }
        public string DisplayName { get; set; }

        public static string BuildApiPath(int membershipType, string displayName)
        {
            return $"SearchDestinyPlayer/{membershipType}/{displayName}";
        }
    }
}