using System.ComponentModel.DataAnnotations.Schema;

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
    
    private readonly List<BaseEvent> _DomainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> EventualConsistencyDomainEvents => _DomainEvents.AsReadOnly();
    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _DomainEvents.Add(domainEvent);
    }

    public void ClearEventualConsistencyDomainEvents()
    {
        _DomainEvents.Clear();
    }
}