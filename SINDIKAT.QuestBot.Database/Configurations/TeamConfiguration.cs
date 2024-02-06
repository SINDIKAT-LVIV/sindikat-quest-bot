using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder
            .ToTable(Tables.Team, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.Team);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(p => p.EntryCode)
            .HasMaxLength(10)
            .IsRequired();

        builder
            .HasMany(p => p.Players)
            .WithOne(p => p.Team)
            .HasForeignKey(Indentifiers.Player);

        builder
            .HasOne(p => p.Quest)
            .WithMany(p => p.Teams)
            .HasForeignKey(Indentifiers.Quest);

        builder
            .HasMany(p => p.QuestSteps)
            .WithOne(p => p.Team)
            .HasForeignKey(Indentifiers.TeamQuestStep);
    }
}