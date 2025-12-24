namespace Tasker.Domain.Entities.Task;

public record Title()
{
    public Title(string value) : this()
    {
        Value = value;
    }

    public required string Value
    {
        get;
        set => field = value.Trim();
    }
}