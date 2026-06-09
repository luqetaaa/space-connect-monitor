using SpaceConnectMonitor.Models;
using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Services;

public interface IClassificadorRiscoService
{
    EventoEspacial CriarEvento(CriarEventoRequest request);
}
