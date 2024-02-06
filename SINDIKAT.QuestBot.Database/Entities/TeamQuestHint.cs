using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class TeamQuestHint : Entity<Guid>
{
    public Team Team { get; set; }
    public Quest Quest { get; set; }
    public QuestHint QuestHint { get; set; }
    public TeamQuestStep TeamQuestStep { get; set; }
    public DateTime ReceivedAt { get; set; }
}