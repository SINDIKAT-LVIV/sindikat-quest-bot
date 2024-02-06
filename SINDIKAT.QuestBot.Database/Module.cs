using Microsoft.Extensions.DependencyInjection;

namespace SINDIKAT.QuestBot.Database;

public static class Module
{
    public static IServiceCollection AddQuestDb(this IServiceCollection services) => services
        .AddDbContext<QuestContext>();
}