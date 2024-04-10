using Application.Base;
using Application.Base.Dtos;
using Application.Modules.InsuranceRequests.Dtos;
using Domain.Modules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.InsuranceCharges.Queries;

public class GetInsuranceRequestListQuery : IRequest<PagedListDto<InsuranceRequestDto>>
{
    public int? Take { get; set; }
    public int? Skip { get; set; }
}

public class GetInsuranceChargeHandler : IRequestHandler<GetInsuranceRequestListQuery,PagedListDto<InsuranceRequestDto>>
{
    private readonly IDatabaseContext _dbContext;

    public GetInsuranceChargeHandler(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<PagedListDto<InsuranceRequestDto>> Handle(GetInsuranceRequestListQuery request, CancellationToken cancellationToken)
    {
        var queryable = _dbContext.InsuranceRequests.Where(r => r.Deleted != true);

        if (request.Take != null && request.Skip!= null)
        {
            queryable = queryable.Take((int)request.Take).Skip((int)request.Skip);
        }

        queryable = queryable.OrderByDescending(c => c.ID);
        var insuranceRequests = await queryable.ToListAsync();
        var result = new PagedListDto<InsuranceRequestDto>();
        foreach (var insuranceRequest in insuranceRequests)
        {
            var insuranceRequestDto = new InsuranceRequestDto(insuranceRequest);
            result.List.Add(insuranceRequestDto);
        }
        return result;
    }
}
