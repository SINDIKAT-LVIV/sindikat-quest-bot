using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class Team : Entity<Guid>
{
    
    public Quest Quest { get; set; }
    public ICollection<TeamQuestStep> QuestSteps { get; set; }
    public ICollection<Player> Players { get; set; }
    public string EntryCode { get; set; }
    public string Name { get; set; }
}