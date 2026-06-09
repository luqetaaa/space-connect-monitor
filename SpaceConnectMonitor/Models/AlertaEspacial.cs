namespace SpaceConnectMonitor.Models;

public class AlertaEspacial
{
    public int EventoId { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    public DateTime GeradoEm { get; set; }
}
