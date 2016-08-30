using System.Collections.Generic;

namespace Destiny.Net.Core.Model.Responses
{
    public class GetAccountSummaryResponse : DestinyResponse
    {
        public override string Id => MembershipId;
        public string MembershipId { get; set; }
        public int MembershipType { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public string ClanName { get; set; }
        public string ClanTag { get; set; }
        public int GrimoireScore { get; set; }

        public static string BuildApiPath(int membershipType, string destinyMembershipId)
        {
            return $"{membershipType}/Account/{destinyMembershipId}/Summary/";
        }
    }
}