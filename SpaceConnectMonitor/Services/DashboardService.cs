using SpaceConnectMonitor.Data;
using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Services;

public class DashboardService : IDashboardService
{
    private readonly IEventoRepository _repository;

    public DashboardService(IEventoRepository repository)
    {
        _repository = repository;
    }

    public async Task<DashboardResumoDto> ObterResumoAsync(CancellationToken cancellationToken = default)
    {
        var eventos = await _repository.ListarAsync(cancellationToken);
        if (eventos.Count == 0) return new DashboardResumoDto();

        return new DashboardResumoDto
        {
            TotalEventos = eventos.Count,
            TotalCriticos = eventos.Count(e => e.NivelRisco >= 80),
            TotalModerados = eventos.Count(e => e.NivelRisco >= 50 && e.NivelRisco < 80),
            TotalBaixos = eventos.Count(e => e.NivelRisco < 50),
            RiscoMedio = Math.Round((decimal)eventos.Average(e => e.NivelRisco), 2),
            RegiaoMaisAfetada = eventos.GroupBy(e => e.Localizacao.Regiao).OrderByDescending(g => g.Count()).First().Key,
            UltimaDeteccao = eventos.Max(e => e.DataDeteccao)
        };
    }
}
