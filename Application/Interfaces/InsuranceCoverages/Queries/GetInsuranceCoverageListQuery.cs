using Application.Base;
using Application.Interfaces.InsuranceCoverages.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.InsuranceCoverages.Queries;

public class GetInsuranceCoverageListQuery : IRequest<List<InsuranceCoverageDto>>
{
    
}

public class GetInsuranceCoverageListQueryHandler : IRequestHandler<GetInsuranceCoverageListQuery, List<InsuranceCoverageDto>>
{
    private readonly IDatabaseContext _dbContext;

    public GetInsuranceCoverageListQueryHandler(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<InsuranceCoverageDto>> Handle(GetInsuranceCoverageListQuery request, CancellationToken cancellationToken)
    {
        var coverages = _dbContext.InsuranceCoverages.Where(c => c.Deleted != true).ToList();
        return coverages.Select(coverage => new InsuranceCoverageDto(coverage)).ToList();
    }
}
