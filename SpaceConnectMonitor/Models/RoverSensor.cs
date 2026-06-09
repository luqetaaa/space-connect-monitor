namespace SpaceConnectMonitor.Models;

public class RoverSensor : SensorEspacial
{
    public string Missao { get; private set; }

    public RoverSensor(string nome, string missao, DateTime dataUltimaCalibracao)
        : base(nome, "Rover", dataUltimaCalibracao)
    {
        Missao = missao;
    }

    public override decimal CalcularConfiabilidade(DateTime dataDeteccao)
    {
        var dias = Math.Abs((dataDeteccao.Date - DataUltimaCalibracao.Date).Days);
        var confiabilidade = 92m - (dias * 0.05m);
        return Math.Clamp(confiabilidade, 60m, 96m);
    }

    public override string DescreverOrigem() => $"Rover {Nome} da missão {Missao}";
}
