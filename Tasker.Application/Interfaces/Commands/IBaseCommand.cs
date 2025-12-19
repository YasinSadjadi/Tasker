using Tasker.Application.DTOs;
using Tasker.Application.Interfaces.Inputs;
namespace Tasker.Application.Interfaces.Commands;

public interface IBaseCommand<TCreateInput, TUpdateInput> 
    where TCreateInput : ICreateInput
    where TUpdateInput : IUpdateInput
{
    Task CreateAsync(TCreateInput input);
    void Create(TCreateInput input);

    Task UpdateAsync(TUpdateInput input);
    void Update(TUpdateInput input);

    Task DeleteAsync(Guid id);
    void Delete(Guid id);
}
