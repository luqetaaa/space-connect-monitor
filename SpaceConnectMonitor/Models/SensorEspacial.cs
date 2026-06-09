namespace SpaceConnectMonitor.Models;

public abstract class SensorEspacial
{
    public string Nome { get; protected set; }
    public string Tipo { get; protected set; }
    public DateTime DataUltimaCalibracao { get; protected set; }

    protected SensorEspacial(string nome, string tipo, DateTime dataUltimaCalibracao)
    {
        Nome = nome;
        Tipo = tipo;
        DataUltimaCalibracao = dataUltimaCalibracao;
    }

    public abstract decimal CalcularConfiabilidade(DateTime dataDeteccao);

    public virtual string DescreverOrigem() => $"{Tipo} - {Nome}";
}
