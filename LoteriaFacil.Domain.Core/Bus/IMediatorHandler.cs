using LoteriaFacil.Domain.Core.Commands;
using LoteriaFacil.Domain.Core.Events;
using System.Threading.Tasks;

namespace LoteriaFacil.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
