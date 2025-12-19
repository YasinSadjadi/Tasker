using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Tasker.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}
