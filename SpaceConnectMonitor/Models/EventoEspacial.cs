namespace SpaceConnectMonitor.Models;

public class EventoEspacial
{
    public int Id { get; set; }
    public string NomeEvento { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public LocalizacaoVo Localizacao { get; set; } = new("Não informado", 0, 0);
    public DateTime DataDeteccao { get; set; }
    public int Intensidade { get; set; }
    public int NivelRisco { get; set; }
    public string Classificacao { get; set; } = string.Empty;
    public string SensorNome { get; set; } = string.Empty;
    public string SensorTipo { get; set; } = string.Empty;
    public decimal ConfiabilidadeSensor { get; set; }
    public string Status { get; set; } = "Pendente";

    public bool EhCritico() => NivelRisco >= 80;
}
