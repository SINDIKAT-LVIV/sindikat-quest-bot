using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SINDIKAT.QuestBot.Database.Entities;
using SINDIKAT.QuestBot.Database.Metadata;

namespace SINDIKAT.QuestBot.Database.Configurations;

public sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder
            .ToTable(Tables.Player, Schemas.Dbo)
            .HasKey(p => p.Id)
            .HasName(Indentifiers.Player);

        builder
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(p => p.Nickname)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasOne(p => p.Team)
            .WithMany(p => p.Players)
            .HasForeignKey(Indentifiers.Team)
            .IsRequired();
    }
}