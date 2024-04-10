using Domain.Base;

namespace Domain.Modules;

/// <summary>
/// پوشش بیمه
/// </summary>
public class InsuranceCoverage : BaseEntity
{
    public string Title { get; set; }
    public double MinimumFund { get; set; }
    public double MaximumFund { get; set; }
    public double Multiplier { get; set; }

    public virtual List<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; } = new();

    public InsuranceCoverage()
    {
        GuID = Guid.NewGuid().ToString();
    }

    public InsuranceCoverage(string title, double minimumFund, double maximumFund, double multiplier)
    {
        Title = title;
        MinimumFund = minimumFund;
        MaximumFund = maximumFund;
        Multiplier = multiplier;
        GuID = Guid.NewGuid().ToString();
    }
}