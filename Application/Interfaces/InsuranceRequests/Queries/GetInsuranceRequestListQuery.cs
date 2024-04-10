using Application.Base;
using MediatR;

namespace Application.Interfaces.InsuranceCharges.Queries;

public class GetInsuranceRequestListQuery : IRequest<decimal>
{
    public int Take { get; set; }
    public int Skip { get; set; }
}

public class GetInsuranceChargeHandler : IRequestHandler<GetInsuranceRequestListQuery,decimal>
{
    private readonly IDatabaseContext _dbContext;

    public GetInsuranceChargeHandler(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<decimal> Handle(GetInsuranceRequestListQuery request, CancellationToken cancellationToken)
    {
        decimal result = 111;
        return result;
    }
}
