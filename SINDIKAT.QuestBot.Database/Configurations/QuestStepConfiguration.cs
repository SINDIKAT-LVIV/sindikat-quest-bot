using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class QuestStepConfiguration : IEntityTypeConfiguration<QuestStep>
{
    public void Configure(EntityTypeBuilder<QuestStep> builder)
    {
        builder
            .ToTable(Tables.QuestStep, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.QuestStep);

        builder
            .Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.ImageContent);
        
        builder
            .Property(p => p.Answer)
            .HasMaxLength(5)
            .IsRequired();

        builder
            .HasOne(p => p.Quest)
            .WithMany(p => p.Steps)
            .HasForeignKey(Indentifiers.Quest)
            .IsRequired();

        builder
            .HasOne(p => p.Previous)
            .WithOne(p => p.Next)
            .HasForeignKey(Indentifiers.QuestStep);

        builder
            .HasOne(p => p.Next)
            .WithOne(p => p.Previous)
            .HasForeignKey(Indentifiers.QuestStep);

        builder
            .HasMany(p => p.Hints)
            .WithOne(p => p.Step)
            .HasForeignKey(Indentifiers.QuestHint);
    }
}