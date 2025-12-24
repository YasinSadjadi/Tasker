namespace Tasker.Domain.Entities.Task;

public record Description
{
    public Description(string? value)
    {
        Value = value;
    }

    public string? Value
    {
        get;
        set => field = value?.Trim();
    }
}