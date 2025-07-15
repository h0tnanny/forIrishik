namespace Domain.Channels;

public interface IChannel
{
    public Guid Id { get; }
    public ChannelType ChannelType { get; }
    public MathCondition? MathCondition { get; }

    public List<IChannelDepended> DependsOnChannels { get; }
    public List<IChannelDepended> DependedByChannels { get; }
    
    public void SetMathCondition(MathCondition? mathCondition);
    
    public void AddDependsOnChannel(IChannelDepended channel);
    public void AddDependedByChannel(IChannelDepended channel);
}