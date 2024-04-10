using Domain.Modules;

namespace Application.Interfaces.InsuranceCoverages.Dtos;

public class InsuranceCoverageDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double MinimumFund { get; set; }
    public double MaximumFund { get; set; }
    public double Multiplier { get; set; }

    public InsuranceCoverageDto(InsuranceCoverage model)
    {
        Id = model.ID;
        Title = model.Title;
        MinimumFund = model.MinimumFund;
        MaximumFund = model.MaximumFund;
        Multiplier = model.Multiplier;
    }
}