using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class QuestStep : Entity<Guid>
{
    public Quest? Quest { get; set; }
    public QuestStep? Previous { get; set; }
    public QuestStep? Next { get; set; }
    public List<QuestHint> Hints { get; set; }
    public string Answer { get; set; }
    public string Description { get; set; }
    public string? ImageContent { get; set; }
}