namespace Destiny.Net.Core.Model
{
    public class AccountSummaryCharacter
    {
        public CharacterBase CharacterBase { get; set; }
        public LevelProgression LevelProgression { get; set; }
        public string EmblemPath { get; set; }
        public string BackgroundPath { get; set; }
        public long EmblemHash { get; set; }
        public int CharacterLevel { get; set; }
        public int BaseCharacterLevel { get; set; }
        public bool IsPrestigeLevel { get; set; }
        public decimal PercentToNextLevel { get; set; }
    }
}