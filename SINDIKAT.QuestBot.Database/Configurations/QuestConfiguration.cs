using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder
            .ToTable(Tables.Quest, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.Quest);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.StartDateTime)
            .IsRequired();

        builder
            .Property(p => p.ExpirationTime)
            .IsRequired();

        builder
            .Property(p => p.HintDelayTime)
            .IsRequired();

        builder
            .HasMany(p => p.Steps)
            .WithOne(p => p.Quest)
            .HasForeignKey(Indentifiers.QuestStep);

        builder
            .HasMany(p => p.Teams)
            .WithOne(p => p.Quest)
            .HasForeignKey(Indentifiers.Team);
    }
}