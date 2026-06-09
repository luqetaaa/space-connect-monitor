using Microsoft.AspNetCore.Mvc;
using SpaceConnectMonitor.Data;
using SpaceConnectMonitor.Exceptions;
using SpaceConnectMonitor.Services;
using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Controllers;

[ApiController]
[Route("api/eventos")]
public class EventosController : ControllerBase
{
    private readonly IEventoRepository _repository;
    private readonly IClassificadorRiscoService _classificador;

    public EventosController(IEventoRepository repository, IClassificadorRiscoService classificador)
    {
        _repository = repository;
        _classificador = classificador;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<EventoDto>>> Listar(CancellationToken cancellationToken)
    {
        try
        {
            var eventos = await _repository.ListarAsync(cancellationToken);
            return Ok(eventos.Select(e => new EventoDto
            {
                Id = e.Id,
                NomeEvento = e.NomeEvento,
                TipoEvento = e.TipoEvento,
                Regiao = e.Localizacao.Regiao,
                Latitude = e.Localizacao.Latitude,
                Longitude = e.Localizacao.Longitude,
                DataDeteccao = e.DataDeteccao,
                Intensidade = e.Intensidade,
                NivelRisco = e.NivelRisco,
                Classificacao = e.Classificacao,
                SensorNome = e.SensorNome,
                SensorTipo = e.SensorTipo,
                ConfiabilidadeSensor = e.ConfiabilidadeSensor,
                Status = e.Status
            }));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Falha ao listar eventos espaciais.", detalhe = ex.Message });
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EventoDto>> ObterPorId(int id, CancellationToken cancellationToken)
    {
        var evento = await _repository.ObterPorIdAsync(id, cancellationToken);
        if (evento is null) return NotFound(new { mensagem = "Evento não encontrado." });

        return Ok(new EventoDto
        {
            Id = evento.Id,
            NomeEvento = evento.NomeEvento,
            TipoEvento = evento.TipoEvento,
            Regiao = evento.Localizacao.Regiao,
            Latitude = evento.Localizacao.Latitude,
            Longitude = evento.Localizacao.Longitude,
            DataDeteccao = evento.DataDeteccao,
            Intensidade = evento.Intensidade,
            NivelRisco = evento.NivelRisco,
            Classificacao = evento.Classificacao,
            SensorNome = evento.SensorNome,
            SensorTipo = evento.SensorTipo,
            ConfiabilidadeSensor = evento.ConfiabilidadeSensor,
            Status = evento.Status
        });
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarEventoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var evento = _classificador.CriarEvento(request);
            evento.Id = await _repository.InserirAsync(evento, cancellationToken);
            return CreatedAtAction(nameof(ObterPorId), new { id = evento.Id }, evento);
        }
        catch (EventoInvalidoException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { mensagem = "Erro inesperado ao cadastrar evento.", detalhe = ex.Message });
        }
    }
}
