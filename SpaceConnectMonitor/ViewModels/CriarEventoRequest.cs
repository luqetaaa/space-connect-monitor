namespace SpaceConnectMonitor.ViewModels;

public class CriarEventoRequest
{
    public string NomeEvento { get; set; } = string.Empty;
    public string TipoEvento { get; set; } = string.Empty;
    public string Regiao { get; set; } = string.Empty;
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public DateTime DataDeteccao { get; set; } = DateTime.Today;
    public int Intensidade { get; set; }
    public string SensorTipo { get; set; } = "Satelite";
    public string SensorNome { get; set; } = "Aqua-1";
}
