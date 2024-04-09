using Application.Base;
using Domain.Modules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private readonly IMediator _mediator;
    
    public DbSet<InsuranceCharge> InsuranceCharges => Set<InsuranceCharge>();
    
    public DatabaseContext(DbContextOptions options
        , IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
}