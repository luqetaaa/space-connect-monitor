namespace SpaceConnectMonitor.ViewModels;

public class DashboardResumoDto
{
    public int TotalEventos { get; set; }
    public int TotalCriticos { get; set; }
    public int TotalModerados { get; set; }
    public int TotalBaixos { get; set; }
    public decimal RiscoMedio { get; set; }
    public string RegiaoMaisAfetada { get; set; } = "-";
    public DateTime? UltimaDeteccao { get; set; }
}
