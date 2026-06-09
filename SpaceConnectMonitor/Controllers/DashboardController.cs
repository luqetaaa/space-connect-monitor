using Microsoft.AspNetCore.Mvc;
using SpaceConnectMonitor.Services;
using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("resumo")]
    public async Task<ActionResult<DashboardResumoDto>> Resumo(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _dashboardService.ObterResumoAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Falha ao gerar dashboard.", detalhe = ex.Message });
        }
    }
}
