using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class TeamQuestHintConfiguration : IEntityTypeConfiguration<TeamQuestHint>
{
    public void Configure(EntityTypeBuilder<TeamQuestHint> builder)
    {
        builder
            .ToTable(Tables.TeamQuestHint, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.TeamQuestHint);

        builder
            .Property(p => p.ReceivedAt)
            .IsRequired();
        
        builder
            .HasOne(p => p.Quest)
            .WithMany()
            .HasForeignKey(Indentifiers.Quest)
            .IsRequired();

        builder
            .HasOne(p => p.Team)
            .WithMany()
            .HasForeignKey(Indentifiers.Team)
            .IsRequired();

        builder
            .HasOne(p => p.QuestHint)
            .WithMany()
            .HasForeignKey(Indentifiers.QuestHint)
            .IsRequired();

        builder
            .HasOne(p => p.TeamQuestStep)
            .WithMany(p => p.TeamQuestHints)
            .HasForeignKey(Indentifiers.TeamQuestStep)
            .IsRequired();
    }
}