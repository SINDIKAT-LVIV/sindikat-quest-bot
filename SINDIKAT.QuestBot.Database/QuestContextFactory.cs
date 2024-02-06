using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SINDIKAT.QuestBot.Database;

public class QuestContextFactory : IDesignTimeDbContextFactory<QuestContext>
{
    public QuestContext CreateDbContext(string[] args) => new(
        new LoggerFactory(),
        new OptionsWrapper<DbConnectionString>(
            new DbConnectionString
            {
                Value = "Host=localhost;Port=5432;Database=QuestDB;Username=sa;Password=p@ssw0rd;"
            }
        )
    );
}