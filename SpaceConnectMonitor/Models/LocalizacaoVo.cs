namespace SpaceConnectMonitor.Models;

public sealed class LocalizacaoVo
{
    public string Regiao { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }

    public LocalizacaoVo(string regiao, decimal latitude, decimal longitude)
    {
        if (string.IsNullOrWhiteSpace(regiao))
            throw new ArgumentException("A região monitorada é obrigatória.", nameof(regiao));

        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude deve estar entre -90 e 90.");

        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude deve estar entre -180 e 180.");

        Regiao = regiao.Trim();
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString() => $"{Regiao} ({Latitude}, {Longitude})";
}
