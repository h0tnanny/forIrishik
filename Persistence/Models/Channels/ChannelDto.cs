using Domain;
using Domain.Channels;

namespace Persistence.Models.Channels;

public class ChannelDto
{
    public Guid Id { get; set; }
    public ChannelType ChannelType { get; set; }
    public MathCondition? MathCondition { get; set; }
    public virtual List<ChannelDependencyDto> DependsOnChannels { get; set; } = new();
    public virtual List<ChannelDependencyDto> DependedByChannels { get; set; } = new();
}