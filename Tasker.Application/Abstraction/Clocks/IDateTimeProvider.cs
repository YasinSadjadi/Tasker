namespace Tasker.Application.Abstraction.Clocks;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; set; }
}