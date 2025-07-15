namespace Domain.Channels;

public interface IChannelDepended
{
    public Guid ChannelId { get; }
    public Guid? DependsOnChannelId { get; }
    
    public void SetDependsOnChannelId(Guid? channelId);
}