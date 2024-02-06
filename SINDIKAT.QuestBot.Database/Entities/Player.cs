using CSharpFunctionalExtensions;

namespace SINDIKAT.QuestBot.Database.Entities;

public class Player : Entity<long>
{
    public Team Team { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
}