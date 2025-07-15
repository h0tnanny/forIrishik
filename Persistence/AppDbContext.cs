using Domain;
using Domain.Channels;
using Microsoft.EntityFrameworkCore;
using Persistence.Models.Channels;

namespace Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<ChannelDto> Channels => Set<ChannelDto>();
    public DbSet<ChannelDependencyDto> ChannelsDependencies => Set<ChannelDependencyDto>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        // Id для каналов
        var channel1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var channel2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var channel3Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var channel4Id = Guid.Parse("44444444-4444-4444-4444-444444444444");

        // Seed для ChannelDto
        modelBuilder.Entity<ChannelDto>()
                    .HasData(new ChannelDto
                             {
                                 Id = channel1Id, ChannelType = ChannelType.Mp,
                                 MathCondition = MathCondition.Equal
                             },
                             new ChannelDto
                             {
                                 Id = channel2Id, ChannelType = ChannelType.Us,
                                 MathCondition = MathCondition.Greater
                             },
                             new ChannelDto
                             {
                                 Id = channel3Id, ChannelType = ChannelType.Vsp,
                                 MathCondition = MathCondition.LessOrEqual
                             },
                             new ChannelDto
                             {
                                 Id = channel4Id, ChannelType = ChannelType.Sbol,
                                 MathCondition = MathCondition.Less
                             }
                            );

        // Seed для ChannelDependencyDto
        modelBuilder.Entity<ChannelDependencyDto>()
                    .HasData(
                             new ChannelDependencyDto { ChannelId = channel2Id, DependsOnChannelId = channel1Id },
                             new ChannelDependencyDto { ChannelId = channel3Id, DependsOnChannelId = channel1Id },
                             new ChannelDependencyDto { ChannelId = channel3Id, DependsOnChannelId = channel2Id },
                             new ChannelDependencyDto { ChannelId = channel4Id, DependsOnChannelId = channel3Id }
                            );
    }
}