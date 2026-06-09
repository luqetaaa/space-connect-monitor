namespace SpaceConnectMonitor.Models;

public class SateliteSensor : SensorEspacial
{
    public string Orbita { get; private set; }

    public SateliteSensor(string nome, string orbita, DateTime dataUltimaCalibracao)
        : base(nome, "Satélite", dataUltimaCalibracao)
    {
        Orbita = orbita;
    }

    public override decimal CalcularConfiabilidade(DateTime dataDeteccao)
    {
        var dias = Math.Abs((dataDeteccao.Date - DataUltimaCalibracao.Date).Days);
        var confiabilidade = 98m - (dias * 0.03m);
        return Math.Clamp(confiabilidade, 70m, 99m);
    }

    public override string DescreverOrigem() => $"Satélite {Nome} em órbita {Orbita}";
}
