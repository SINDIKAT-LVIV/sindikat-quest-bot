using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class QuestHint : Entity<Guid>
{
    public QuestStep Step { get; set; }
    public string Description { get; set; }
    public string? ImageContent { get; set; }
    public int OrderNumber { get; set; }
}