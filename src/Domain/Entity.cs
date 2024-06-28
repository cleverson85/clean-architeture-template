namespace Domain;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        AddDate = DateOnly.FromDateTime(DateTime.Now);
    }

    public Guid Id { get; private set; }  
    public DateOnly AddDate { get; private set;  }
}
