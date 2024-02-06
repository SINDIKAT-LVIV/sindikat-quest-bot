using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class QuestHintConfiguration : IEntityTypeConfiguration<QuestHint>
{
    public void Configure(EntityTypeBuilder<QuestHint> builder)
    {
        builder
            .ToTable(Tables.QuestHint, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.QuestHint);

        builder
            .Property(p => p.Description)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.ImageContent);
        
        builder
            .Property(p => p.OrderNumber)
            .IsRequired();

        builder
            .HasOne(p => p.Step)
            .WithMany(p => p.Hints)
            .HasForeignKey(Indentifiers.QuestStep)
            .IsRequired();
    }
}