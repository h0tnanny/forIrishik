using Domain.Channels;

namespace Persistence.Models.Channels.Extensions;

public static class ChannelDtoExtensions
{
    public static ChannelDto MapToDto(this IChannel channel)
    {
        var dto = new ChannelDto
        {
            Id = channel.Id,
            MathCondition = channel.MathCondition,
            ChannelType = channel.ChannelType,
            DependsOnChannels = channel.DependsOnChannels.Select(x => new ChannelDependencyDto
            {
                ChannelId = x.ChannelId,
                DependsOnChannelId = x.DependsOnChannelId
            }).ToList(),
            DependedByChannels = channel.DependedByChannels.Select(x => new ChannelDependencyDto
            {
                ChannelId = x.ChannelId,
                DependsOnChannelId = x.DependsOnChannelId
            }).ToList()
        };
        
        return dto;
    }
}