using SpaceConnectMonitor.Exceptions;
using SpaceConnectMonitor.Models;
using SpaceConnectMonitor.ViewModels;

namespace SpaceConnectMonitor.Services;

public class ClassificadorRiscoService : IClassificadorRiscoService
{
    public EventoEspacial CriarEvento(CriarEventoRequest request)
    {
        Validar(request);

        SensorEspacial sensor = CriarSensor(request.SensorTipo, request.SensorNome);
        var confiabilidade = sensor.CalcularConfiabilidade(request.DataDeteccao);
        var diasDesdeDeteccao = Math.Max(0, (DateTime.Today - request.DataDeteccao.Date).Days);
        var fatorRecencia = diasDesdeDeteccao <= 1 ? 10 : diasDesdeDeteccao <= 7 ? 5 : 0;
        var riscoCalculado = request.Intensidade + fatorRecencia + (confiabilidade >= 90 ? 5 : 0);
        var nivelRisco = Math.Clamp(riscoCalculado, 0, 100);

        return new EventoEspacial
        {
            NomeEvento = request.NomeEvento.Trim(),
            TipoEvento = request.TipoEvento.Trim(),
            Localizacao = new LocalizacaoVo(request.Regiao, request.Latitude, request.Longitude),
            DataDeteccao = request.DataDeteccao.Date,
            Intensidade = request.Intensidade,
            NivelRisco = nivelRisco,
            Classificacao = Classificar(nivelRisco),
            SensorNome = sensor.Nome,
            SensorTipo = sensor.Tipo,
            ConfiabilidadeSensor = confiabilidade,
            Status = nivelRisco >= 80 ? "Ação imediata" : nivelRisco >= 50 ? "Monitorar" : "Observação"
        };
    }

    private static SensorEspacial CriarSensor(string tipo, string nome)
    {
        if (tipo.Equals("Rover", StringComparison.OrdinalIgnoreCase))
        {
            return new RoverSensor(nome, "Exploração de ambiente hostil", DateTime.Today.AddDays(-12));
        }

        return new SateliteSensor(nome, "LEO", DateTime.Today.AddDays(-5));
    }

    private static string Classificar(int nivelRisco)
    {
        return nivelRisco switch
        {
            >= 80 => "Crítico",
            >= 50 => "Moderado",
            _ => "Baixo"
        };
    }

    private static void Validar(CriarEventoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.NomeEvento))
            throw new EventoInvalidoException("Informe o nome do evento.");

        if (string.IsNullOrWhiteSpace(request.TipoEvento))
            throw new EventoInvalidoException("Informe o tipo do evento.");

        if (request.Intensidade < 0 || request.Intensidade > 100)
            throw new EventoInvalidoException("A intensidade deve estar entre 0 e 100.");

        if (request.DataDeteccao.Date > DateTime.Today.AddDays(1))
            throw new EventoInvalidoException("A data de detecção não pode estar no futuro distante.");
    }
}
