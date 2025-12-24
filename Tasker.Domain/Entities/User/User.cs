using Tasker.Domain.Abstractions.Interfaces;
using Tasker.Domain.Entities.User.Events;

namespace Tasker.Domain.Entities.User;

public class User : Entity, IDeactivable
{
    private User(
        Guid id,
        FirstName firstName,
        LastName lastName,
        EmailAddress emailAddress) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public EmailAddress EmailAddress { get; private set; }

    public bool IsActive { get; private set; }

    public void Deactive()
    {
        if (IsActive)
            IsActive = false;
        else
            throw new InvalidOperationException();

        RaiseDomainEvent(new UserActivatedDomainEvent(Id));
    }

    public void Active()
    {
        if (!IsActive)
            IsActive = true;
        else
            throw new InvalidOperationException();

        RaiseDomainEvent(new UserDeactivatedDomainEvent(Id));
    }

    public static User Create(FirstName firstName, LastName lastName, EmailAddress emailAddress)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, emailAddress);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}