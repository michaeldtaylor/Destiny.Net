using System;

namespace Destiny.Net.Core.Model
{
    public class CharacterBase
    {
        public string MembershipId { get; set; }
        public int MembershipType { get; set; }
        public string CharacterId { get; set; }
        public DateTime DateLastPlayed { get; set; }
        public int PowerLevel { get; set; }
        public long RaceHash { get; set; }
        public long GenderHash { get; set; }
        public long ClassHash { get; set; }
    }
}