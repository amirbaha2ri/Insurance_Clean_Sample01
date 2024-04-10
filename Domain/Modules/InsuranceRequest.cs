using Domain.Base;

namespace Domain.Modules;

/// <summary>
/// درخواست بیمه
/// </summary>
public class InsuranceRequest : BaseEntity
{
    public string Title { get; set; }
    public virtual List<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; } = new();
    public double Fund { get; set; }

    public InsuranceRequest()
    {
        GuID = Guid.NewGuid().ToString();
    }

    public InsuranceRequest(string title, double fund)
    {
        Title = title;
        Fund = fund;
    }
}