using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class TeamQuestStepConfiguration : IEntityTypeConfiguration<TeamQuestStep>
{
    public void Configure(EntityTypeBuilder<TeamQuestStep> builder)
    {
        builder
            .ToTable(Tables.TeamQuestStep, Schemas.Dbo)
            .HasKey(p => p.TeamQuestHints)
            .HasName(Indentifiers.TeamQuestStep);

        builder
            .Property(p => p.StartedAt)
            .IsRequired();

        builder.Property(p => p.CompletedAt);

        builder
            .HasOne(p => p.Team)
            .WithMany(p => p.QuestSteps)
            .HasForeignKey(Indentifiers.Team)
            .IsRequired();

        builder
            .HasOne(p => p.Quest)
            .WithMany()
            .HasForeignKey(Indentifiers.Quest)
            .IsRequired();

        builder
            .HasOne(p => p.QuestStep)
            .WithMany()
            .HasForeignKey(Indentifiers.QuestStep)
            .IsRequired();

        builder
            .HasMany(tqs => tqs.TeamQuestHints)
            .WithOne(tqh => tqh.TeamQuestStep);
    }
}