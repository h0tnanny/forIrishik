using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Models.Channels.Configurations;

public sealed class ChannelDtoConfiguration : IEntityTypeConfiguration<ChannelDto>
{
    public void Configure(EntityTypeBuilder<ChannelDto> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.DependsOnChannels)
               .WithOne(cd => cd.Channel)
               .HasForeignKey(cd => cd.ChannelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.DependedByChannels)
               .WithOne(cd => cd.DependsOnChannel)
               .HasForeignKey(cd => cd.DependsOnChannelId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}