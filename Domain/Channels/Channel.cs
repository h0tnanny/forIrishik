namespace Domain.Channels;

public class Channel : IChannel
{
    public Channel(Guid id, 
                   ChannelType channelType, 
                   MathCondition? mathCondition, 
                   List<IChannelDepended> dependsOnChannels, 
                   List<IChannelDepended> dependedByChannels)
    {
        Id = id;
        ChannelType = channelType;
        MathCondition = mathCondition;
        DependsOnChannels = dependsOnChannels;
        DependedByChannels = dependedByChannels;
    }

    public Guid Id { get; }
    public ChannelType ChannelType { get; }
    public MathCondition? MathCondition { get; private set; }
    public List<IChannelDepended> DependsOnChannels { get; }
    public List<IChannelDepended> DependedByChannels { get; }
    
    public void SetMathCondition(MathCondition? mathCondition)
    {
        MathCondition = mathCondition;
    }

    public void AddDependsOnChannel(IChannelDepended channel)
    {
        DependsOnChannels.Add(channel);
    }

    public void AddDependedByChannel(IChannelDepended channel)
    {
        DependedByChannels.Add(channel);
    }
}