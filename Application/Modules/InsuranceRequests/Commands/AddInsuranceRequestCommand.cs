using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Base;
using Domain.Modules;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.InsuranceRequests.Commands;

public class AddInsuranceRequestCommand : IRequest<Unit>
{
    [Required]
    public string Title { get; set; }

    [Required] 
    public List<int> InsuranceCoverageIds { get; set; } = new();
    
    [Required]
    public double Fund { get; set; }
}

public class AddInsuranceRequestCommandHandler : IRequestHandler<AddInsuranceRequestCommand, Unit>
{
    private readonly IDatabaseContext _dbContext;

    public AddInsuranceRequestCommandHandler(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(AddInsuranceRequestCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Title))
        {
            throw new ApplicationException("Title is not valid.",null);
        }

        if (! request.InsuranceCoverageIds.Any())
        {
            throw new ApplicationException("Coverage list is empty.",null);
        }

        var insuranceCoverages =
            await _dbContext.InsuranceCoverages.Where(c => c.Deleted != true && request.InsuranceCoverageIds.Contains(c.ID)).ToListAsync();
        
        var insuranceRequest = new InsuranceRequest(request.Title, request.Fund);
        insuranceRequest.CreateDate = DateTime.Now;
        insuranceRequest.InsuranceRequestCoverages = new List<InsuranceRequestCoverage>();
        foreach (var insuranceCoverage in insuranceCoverages)
        {
            if (request.Fund > insuranceCoverage.MaximumFund || request.Fund < insuranceCoverage.MinimumFund)
            {
                throw new ApplicationException($"Fund is not acceptable for coverage: {insuranceCoverage.Title}.");
            }
            insuranceRequest.Premium += insuranceCoverage.Multiplier * request.Fund;
            insuranceRequest.InsuranceRequestCoverages.Add(new InsuranceRequestCoverage(){InsuranceCoverage = insuranceCoverage});
        }

        await _dbContext.InsuranceRequests.AddAsync(insuranceRequest);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
    
}
