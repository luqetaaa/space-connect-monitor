using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Services;

public interface IDashboardService
{
    Task<DashboardResumoDto> ObterResumoAsync(CancellationToken cancellationToken = default);
}
