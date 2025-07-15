using Microsoft.EntityFrameworkCore;
using Persistence.Models.Channels;

namespace Persistence.Repositories;

public class ChannelDependencyRepository(AppDbContext dbContext)
{
    public async Task<IReadOnlyCollection<ChannelDependencyDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.ChannelsDependencies
                        .Include(x => x.Channel)
                        .Include(x => x.DependsOnChannel)
                        .ToListAsync(cancellationToken);
    }
}