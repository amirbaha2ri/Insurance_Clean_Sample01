using Application.Base;
using Domain.Base;
using Domain.Modules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private readonly IMediator _mediator;
    
    public DbSet<InsuranceRequest> InsuranceRequests => Set<InsuranceRequest>();
    public DbSet<InsuranceCoverage> InsuranceCoverages => Set<InsuranceCoverage>();
    public DbSet<InsuranceRequestCoverage> InsuranceRequestCoverages => Set<InsuranceRequestCoverage>();

    
    public DatabaseContext(DbContextOptions options
        , IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var res = await base.SaveChangesAsync(cancellationToken);

        var entities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.EventualConsistencyDomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.EventualConsistencyDomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearEventualConsistencyDomainEvents());

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent, cancellationToken);

        return res;
    }
}