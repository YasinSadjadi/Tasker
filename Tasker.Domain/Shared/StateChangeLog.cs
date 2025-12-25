namespace Tasker.Domain.Shared;

public record StateChangeLog
{
    public DateTime? HappenedDate
    {
        get => field?.ToLocalTime();
        private set;
    }

    public static StateChangeLog Create()
    {
        return new StateChangeLog { HappenedDate = DateTime.UtcNow };
    }

    public static StateChangeLog Create(DateTime date)
    {
        return new StateChangeLog { HappenedDate = date };
    }

    public static StateChangeLog Empty()
    {
        return new StateChangeLog { HappenedDate = null };
    }
}