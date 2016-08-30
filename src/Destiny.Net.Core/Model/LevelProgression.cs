namespace Destiny.Net.Core.Model
{
    public class LevelProgression
    {
        public long DailyProgress { get; set; }
        public long WeeklyProgress { get; set; }
        public long CurrentProgress { get; set; }
        public long Level { get; set; }
        public long Step { get; set; }
        public long ProgressToNextLevel { get; set; }
        public long NextLevelAt { get; set; }
        public long ProgressionHash { get; set; }
    }
}