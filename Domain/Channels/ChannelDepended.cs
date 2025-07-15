namespace Domain.Channels;

public sealed class ChannelDepended : IChannelDepended
{
    public ChannelDepended(Guid channelId, Guid? dependsOnChannelId)
    {
        ChannelId = channelId;
        DependsOnChannelId = dependsOnChannelId;
    }

    public Guid ChannelId { get; }
    public Guid? DependsOnChannelId { get; private set; }
    
    public void SetDependsOnChannelId(Guid? channelId)
    {
        DependsOnChannelId = channelId;
    }
}