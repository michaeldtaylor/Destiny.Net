using System;

namespace Destiny.Net.Core.Model
{
    public class DestinyAccountCharacter
    {
        public string CharacterId { get; set; }
        public Race Race { get; set; }
        public Gender Gender { get; set; }
        public CharacterClass CharacterClass { get; set; }
        public string EmblemPath { get; set; }
        public string BackgroundPath { get; set; }
        public int Level { get; set; }
        public int PowerLevel { get; set; }
        public DateTime DateLastPlayed { get; set; }
    }
}