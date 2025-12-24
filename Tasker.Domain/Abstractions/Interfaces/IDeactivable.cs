namespace Tasker.Domain.Abstractions.Interfaces;

public interface IDeactivable
{
    bool IsActive { get; }

    void Deactive();
    void Active();
}
