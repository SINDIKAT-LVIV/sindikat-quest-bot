using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SINDIKAT.QuestBot.Database;

public partial class QuestContext(
    ILoggerFactory loggerFactory, 
    IOptions<DbConnectionString> connectionString) : DbContext
{
    private readonly DbConnectionString _connectionString = connectionString.Value;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLoggerFactory(loggerFactory)
            .UseNpgsql(_connectionString.Value);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(QuestContext).Assembly);
    }
}