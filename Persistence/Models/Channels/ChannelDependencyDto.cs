namespace Persistence.Models.Channels;

public sealed class ChannelDependencyDto
{
    public Guid ChannelId { get; set; }
    public ChannelDto Channel { get; set; }

    public Guid? DependsOnChannelId { get; set; }
    public ChannelDto? DependsOnChannel { get; set; }
}