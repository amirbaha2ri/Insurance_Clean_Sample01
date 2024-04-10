using Domain.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Base;

public interface IDatabaseContext
{
    DbSet<InsuranceRequest> InsuranceRequests { get; }
    DbSet<InsuranceCoverage> InsuranceCoverages { get; }
    DbSet<InsuranceRequestCoverage> InsuranceRequestCoverages { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}