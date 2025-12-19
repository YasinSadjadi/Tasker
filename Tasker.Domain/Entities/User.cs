using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tasker.Domain.Interfaces;
using Tasker.Helper;

namespace Tasker.Domain.Entities;

[Index(nameof(EmailAddress), IsUnique = true)]
[Index(nameof(UserName), IsUnique = true)]
public class User : BaseEntity, IDeactivable
{
    [EmailAddress]
    public string EmailAddress { get; set => value.Trim(); } = default!;

    public string UserName { get; set => value.Trim(); } = default!;

    public UserPassword Password { get; private set; } = default!;
    public bool IsActive { get; set; }

    public ICollection<TaskerTask> AssignedTasks { get; set; } = [];
    public ICollection<TaskerTask> CreatedTasks { get; set; } = [];


    [Owned]
    public record UserPassword
    {
        public UserPassword(string password) => SetPassword(password);

        public UserPassword(string passwordHash, bool IsHashed)
        {
            if (IsHashed)
            {
                PasswordHash = passwordHash;
            }
            else
            {
                SetPassword(passwordHash);
            }
        }

        public string PasswordHash { get; private set; } = default!;

        public void SetPassword(string plainTextPassword)
        {
            PasswordHash = PasswordHasher.Hash(plainTextPassword.Trim());
        }
    }
}

