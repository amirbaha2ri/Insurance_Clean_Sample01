using Domain.Base;

namespace Domain.Modules;

/// <summary>
/// درخواست بیمه
/// </summary>
public class InsuranceRequest : BaseEntity
{
    /// <summary>
    /// عنوان
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// لیست پوشش‌های بیمه
    /// </summary>
    public virtual List<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; } = new();
    
    /// <summary>
    /// سرمایه
    /// </summary>
    public double Fund { get; set; }
    
    /// <summary>
    /// حق بیمه
    /// </summary>
    public double Premium { get; set; }

    public InsuranceRequest()
    {
        GuID = Guid.NewGuid().ToString();
    }

    public InsuranceRequest(string title, double fund)
    {
        Title = title;
        Fund = fund;
        GuID = Guid.NewGuid().ToString();
    }
}