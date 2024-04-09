namespace Domain.Base;

public class BaseEntity
{
    public string GuID { get; set; }
    public int ID { get; set; }
    public DateTime CreateDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Deleted { get; set; }
    public int? Code { get; set; }
    public virtual void Delete()
    {
        Deleted = true;
    }
}