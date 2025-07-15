using LearnProjects.Utils;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;

namespace LearnProjects;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
               });
        builder.Services.AddSwaggerAndScalar();

        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("InMemoryDatabase");
        });
        builder.Services.AddScoped<ChannelRepository>();
        builder.Services.AddScoped<ChannelDependencyRepository>();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseSwaggerAndScalar();

        app.MapControllers();
        await app.RunAsync();
    }
}
