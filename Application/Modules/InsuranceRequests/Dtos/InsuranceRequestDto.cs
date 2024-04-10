using Application.Interfaces.InsuranceCoverages.Dtos;
using Domain.Modules;

namespace Application.Modules.InsuranceRequests.Dtos;

public class InsuranceRequestDto
{
    public string Title { get; set; }
    public double Fund { get; set; }
    public List<InsuranceCoverageDto> Coverages { get; set; }

    public InsuranceRequestDto()
    {
        
    }

    public InsuranceRequestDto(InsuranceRequest model)
    {
        Title = model.Title;
        Fund = model.Fund;
        Coverages = new List<InsuranceCoverageDto>();
        foreach (var insuranceRequestCoverageCoverage in model.InsuranceRequestCoverages)
        {
            Coverages.Add(new InsuranceCoverageDto(insuranceRequestCoverageCoverage.InsuranceCoverage));
        }
    }
    
}