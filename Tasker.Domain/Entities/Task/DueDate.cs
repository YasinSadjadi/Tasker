namespace Tasker.Domain.Entities.Task;

public record DueDate
{

    public DateTime? Value
    {
        get;
        set
        {
            if (value?.ToUniversalTime() < DateTime.UtcNow)
            {
                throw new InvalidOperationException();
            }
            field = value;
        }
    }
};