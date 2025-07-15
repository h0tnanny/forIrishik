using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Models.Channels.Configurations;

public sealed class ChannelDependencyDtoConfiguration : IEntityTypeConfiguration<ChannelDependencyDto>
{
    public void Configure(EntityTypeBuilder<ChannelDependencyDto> builder)
    {
        builder.HasKey(cd => new { cd.ChannelId, cd.DependsOnChannelId });

        builder.HasOne(cd => cd.Channel)
               .WithMany(c => c.DependsOnChannels)
               .HasForeignKey(cd => cd.ChannelId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cd => cd.DependsOnChannel)
               .WithMany(c => c.DependedByChannels)
               .HasForeignKey(cd => cd.DependsOnChannelId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}