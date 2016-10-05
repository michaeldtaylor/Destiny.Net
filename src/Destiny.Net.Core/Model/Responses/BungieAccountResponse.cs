using System.Collections.Generic;

namespace Destiny.Net.Core.Model.Responses
{
    public class BungieAccountResponse : DestinyResponse
    {
        public IEnumerable<DestinyAccount> DestinyAccounts { get; set; }
        public IEnumerable<Clan> Clans { get; set; }
        public Dictionary<string, RelatedGroup> RelatedGroups { get; set; }
    }
}