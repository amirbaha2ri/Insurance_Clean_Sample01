using Domain.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Base;

public interface IDatabaseContext
{
    DbSet<InsuranceCharge> InsuranceCharges { get; }
    

    
}