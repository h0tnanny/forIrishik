using Microsoft.AspNetCore.Mvc;
using Persistence.Models.Channels;
using Persistence.Repositories;

namespace LearnProjects.Controllers;


[ApiController]
[Route("[controller]")]
public sealed class ChannelController(ChannelRepository repository, ChannelDependencyRepository channelDependencyRepository) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ChannelDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var channels = await channelDependencyRepository.GetAllAsync(cancellationToken);
        return Ok(channels);
    }
}