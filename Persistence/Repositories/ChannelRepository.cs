using Domain.Channels;
using Microsoft.EntityFrameworkCore;
using Persistence.Models.Channels;
using Persistence.Models.Channels.Extensions;

namespace Persistence.Repositories;

public sealed class ChannelRepository(AppDbContext dbContext)
{
    public async Task<IReadOnlyCollection<ChannelDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await dbContext.Channels
                                    .Include(x => x.DependsOnChannels)
                                    .Include(x => x.DependedByChannels)
                                    .ToListAsync(cancellationToken);
        return result;
    }

    public async Task<ChannelDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await dbContext.Channels
                                     .SingleAsync(x => x.Id == id, cancellationToken);
        return result;
    }

    public void Add(IChannel channel)
    {
        var dto = channel.MapToDto();
        
        dbContext.Channels.Add(dto);
        dbContext.ChannelsDependencies.AddRange(dto.DependedByChannels);
        dbContext.ChannelsDependencies.AddRange(dto.DependsOnChannels);
        
        dbContext.SaveChanges();
    }
}