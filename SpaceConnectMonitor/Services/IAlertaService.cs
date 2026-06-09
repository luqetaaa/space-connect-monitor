using SpaceConnectMonitor.Models;

namespace SpaceConnectMonitor.Services;

public interface IAlertaService
{
    AlertaEspacial GerarAlerta(EventoEspacial evento);
    Task<IReadOnlyList<AlertaEspacial>> ListarAlertasAsync(CancellationToken cancellationToken = default);
}
