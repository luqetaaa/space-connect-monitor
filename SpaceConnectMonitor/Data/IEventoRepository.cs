using SpaceConnectMonitor.Models;

namespace SpaceConnectMonitor.Data;

public interface IEventoRepository
{
    Task<IReadOnlyList<EventoEspacial>> ListarAsync(CancellationToken cancellationToken = default);
    Task<EventoEspacial?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<int> InserirAsync(EventoEspacial evento, CancellationToken cancellationToken = default);
}
