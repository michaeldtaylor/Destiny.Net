using System.Collections.Generic;

namespace Destiny.Net.Core.Model
{
    public class DestinyAccount
    {
        public UserInfo UserInfo { get; set; }
        public int GrimoireScore { get; set; }
        public IEnumerable<DestinyAccountCharacter> Characters { get; set; }
    }
}