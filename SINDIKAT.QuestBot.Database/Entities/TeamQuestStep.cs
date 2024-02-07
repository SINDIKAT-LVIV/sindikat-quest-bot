using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class TeamQuestStep : Entity<Guid>
{
    public Team Team { get; set; }
    public Quest Quest { get; set; }
    public QuestStep QuestStep { get; set; }
    public virtual ICollection<TeamQuestHint> TeamQuestHints { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}