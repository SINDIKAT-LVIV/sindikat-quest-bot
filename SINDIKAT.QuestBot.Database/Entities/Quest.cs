using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class Quest : Entity<Guid>
{
    public ICollection<QuestStep> Steps { get; set; }
    public ICollection<Team> Teams { get; set; }
    public string Name { get; set; }
    public DateTime StartDateTime { get; set; }
    public TimeOnly ExpirationTime { get; set; }
    public TimeOnly HintDelayTime { get; set; }
}