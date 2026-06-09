namespace SpaceConnectMonitor.ViewModels;

public class EventoDto
{
    public int Id { get; set; }
    public string NomeEvento { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string Regiao { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DataDeteccao { get; set; }
    public int Intensidade { get; set; }
    public int NivelRisco { get; set; }
    public string Classificacao { get; set; } = string.Empty;
    public string SensorNome { get; set; } = string.Empty;
    public string SensorTipo { get; set; } = string.Empty;
    public decimal ConfiabilidadeSensor { get; set; }
    public string Status { get; set; } = string.Empty;
}
