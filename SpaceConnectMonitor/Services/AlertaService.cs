using SpaceConnectMonitor.Data;
using SpaceConnectMonitor.Models;

namespace SpaceConnectMonitor.Services;

public class AlertaService : IAlertaService
{
    private readonly IEventoRepository _repository;

    public AlertaService(IEventoRepository repository)
    {
        _repository = repository;
    }

    public AlertaEspacial GerarAlerta(EventoEspacial evento)
    {
        var prioridade = evento.NivelRisco >= 80 ? "Alta" : evento.NivelRisco >= 50 ? "Média" : "Baixa";
        return new AlertaEspacial
        {
            EventoId = evento.Id,
            Titulo = $"Alerta {evento.Classificacao}: {evento.TipoEvento}",
            Prioridade = prioridade,
            GeradoEm = DateTime.Now,
            Mensagem = $"Evento detectado em {evento.Localizacao.Regiao} com risco {evento.NivelRisco}. Status: {evento.Status}."
        };
    }

    public async Task<IReadOnlyList<AlertaEspacial>> ListarAlertasAsync(CancellationToken cancellationToken = default)
    {
        var eventos = await _repository.ListarAsync(cancellationToken);
        return eventos
            .Where(e => e.NivelRisco >= 50)
            .Select(GerarAlerta)
            .OrderByDescending(a => a.Prioridade == "Alta")
            .ThenByDescending(a => a.EventoId)
            .ToList();
    }
}
