using System.Net;
using Application.Base;
using Domain.Modules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.InsuranceCoverages.Commands;

public class AddInsuranceCoverageCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public double MaximumFund { get; set; }
    public double MinimumFund { get; set; }
    public double Multiplier { get; set; }
}

public class AddInsuranceCoverageCommandHandler : IRequestHandler<AddInsuranceCoverageCommand, Unit>
{
    private readonly IDatabaseContext _dbContext;

    public AddInsuranceCoverageCommandHandler(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(AddInsuranceCoverageCommand request, CancellationToken cancellationToken)
    {
        if (await _dbContext.InsuranceCoverages.AnyAsync(c=>c.Title == request.Title, cancellationToken))
        {
            throw new HttpRequestException("This name is already taken.",null,HttpStatusCode.BadRequest);
        }

        var insuranceCoverage = new InsuranceCoverage(request.Title,request.MaximumFund,request.MinimumFund,request.Multiplier);
        insuranceCoverage.CreateDate = DateTime.Now;
        await _dbContext.InsuranceCoverages.AddAsync(insuranceCoverage,cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
