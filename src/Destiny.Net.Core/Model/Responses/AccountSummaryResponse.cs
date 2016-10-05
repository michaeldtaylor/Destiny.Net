using System.Collections.Generic;

namespace Destiny.Net.Core.Model.Responses
{
    public class AccountSummaryResponse : DestinyResponse
    {
        public string MembershipId { get; set; }
        public int MembershipType { get; set; }
        public IEnumerable<AccountSummaryCharacter> Characters { get; set; }
        public int GrimoireScore { get; set; }
    }
}