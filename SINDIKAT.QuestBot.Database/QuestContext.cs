using Microsoft.EntityFrameworkCore;
using SINDIKAT.QuestBot.Database.Entities;

namespace SINDIKAT.QuestBot.Database;

public class QuestContext : DbContext
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<QuestStep> Steps { get; set; }
    public DbSet<QuestHint> Hints { get; set; }
}