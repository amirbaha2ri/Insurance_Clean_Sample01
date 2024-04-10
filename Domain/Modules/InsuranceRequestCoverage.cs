using Domain.Base;

namespace Domain.Modules;

public class InsuranceRequestCoverage : BaseEntity
{
    public int InsuranceCoverageId { get; set; }
    public int InsuranceRequestId { get; set; }
    
    public virtual InsuranceRequest InsuranceRequest { get; set; }
    public virtual InsuranceCoverage InsuranceCoverage { get; set; }

    public InsuranceRequestCoverage()
    {
        GuID = Guid.NewGuid().ToString();
    }
}