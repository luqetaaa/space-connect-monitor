using Microsoft.AspNetCore.Mvc;
using SpaceConnectMonitor.Models;
using SpaceConnectMonitor.Services;

namespace SpaceConnectMonitor.Controllers;

[ApiController]
[Route("api/alertas")]
public class AlertasController : ControllerBase
{
    private readonly IAlertaService _alertaService;

    public AlertasController(IAlertaService alertaService)
    {
        _alertaService = alertaService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AlertaEspacial>>> Listar(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _alertaService.ListarAlertasAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Falha ao gerar alertas.", detalhe = ex.Message });
        }
    }
}
