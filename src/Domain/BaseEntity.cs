namespace Domain;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        AddDate = DateOnly.FromDateTime(DateTime.Now);
    }

    public Guid Id { get; set; }  
    public DateOnly AddDate { get; private set;  }
}
