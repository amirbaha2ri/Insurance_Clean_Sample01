using Domain.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Base;

public interface IDatabaseContext
{
    DbSet<InsuranceRequest> InsuranceCharges { get; }
    DbSet<InsuranceCoverage> InsuranceCoverages { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}