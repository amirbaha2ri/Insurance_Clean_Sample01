using MediatR;

namespace Application.Interfaces.InsuranceCharges.Queries;

public class GetInsuranceCharge : IRequest<decimal>
{
    
}

public class GetInsuranceChargeHandler : IRequestHandler<GetInsuranceCharge,decimal>
{
    public async Task<decimal> Handle(GetInsuranceCharge request, CancellationToken cancellationToken)
    {
        decimal result = 111;
        return result;
    }
}
