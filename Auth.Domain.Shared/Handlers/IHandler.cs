using Auth.Domain.Shared.Commands;
using System.Threading.Tasks;

namespace Auth.Domain.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
