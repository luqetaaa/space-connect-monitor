using Microsoft.Data.SqlClient;
using SpaceConnectMonitor.Models;

namespace SpaceConnectMonitor.Data;

public class EventoRepository : IEventoRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public EventoRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IReadOnlyList<EventoEspacial>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var eventos = new List<EventoEspacial>();
        await using var connection = (SqlConnection)_connectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);

        const string sql = """
        SELECT Id, NomeEvento, TipoEvento, Regiao, Latitude, Longitude, DataDeteccao, Intensidade,
               NivelRisco, Classificacao, SensorNome, SensorTipo, ConfiabilidadeSensor, Status
        FROM dbo.EventosEspaciais
        ORDER BY DataDeteccao DESC, NivelRisco DESC;
        """;

        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            eventos.Add(Mapear(reader));
        }

        return eventos;
    }

    public async Task<EventoEspacial?> ObterPorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await using var connection = (SqlConnection)_connectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);

        const string sql = """
        SELECT Id, NomeEvento, TipoEvento, Regiao, Latitude, Longitude, DataDeteccao, Intensidade,
               NivelRisco, Classificacao, SensorNome, SensorTipo, ConfiabilidadeSensor, Status
        FROM dbo.EventosEspaciais
        WHERE Id = @Id;
        """;

        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        return await reader.ReadAsync(cancellationToken) ? Mapear(reader) : null;
    }

    public async Task<int> InserirAsync(EventoEspacial evento, CancellationToken cancellationToken = default)
    {
        await using var connection = (SqlConnection)_connectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken);

        const string sql = """
        INSERT INTO dbo.EventosEspaciais
        (NomeEvento, TipoEvento, Regiao, Latitude, Longitude, DataDeteccao, Intensidade, NivelRisco,
         Classificacao, SensorNome, SensorTipo, ConfiabilidadeSensor, Status)
        OUTPUT INSERTED.Id
        VALUES
        (@NomeEvento, @TipoEvento, @Regiao, @Latitude, @Longitude, @DataDeteccao, @Intensidade, @NivelRisco,
         @Classificacao, @SensorNome, @SensorTipo, @ConfiabilidadeSensor, @Status);
        """;

        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@NomeEvento", evento.NomeEvento);
        command.Parameters.AddWithValue("@TipoEvento", evento.TipoEvento);
        command.Parameters.AddWithValue("@Regiao", evento.Localizacao.Regiao);
        command.Parameters.AddWithValue("@Latitude", evento.Localizacao.Latitude);
        command.Parameters.AddWithValue("@Longitude", evento.Localizacao.Longitude);
        command.Parameters.AddWithValue("@DataDeteccao", evento.DataDeteccao);
        command.Parameters.AddWithValue("@Intensidade", evento.Intensidade);
        command.Parameters.AddWithValue("@NivelRisco", evento.NivelRisco);
        command.Parameters.AddWithValue("@Classificacao", evento.Classificacao);
        command.Parameters.AddWithValue("@SensorNome", evento.SensorNome);
        command.Parameters.AddWithValue("@SensorTipo", evento.SensorTipo);
        command.Parameters.AddWithValue("@ConfiabilidadeSensor", evento.ConfiabilidadeSensor);
        command.Parameters.AddWithValue("@Status", evento.Status);

        var result = await command.ExecuteScalarAsync(cancellationToken);
        return Convert.ToInt32(result);
    }

    private static EventoEspacial Mapear(SqlDataReader reader)
    {
        return new EventoEspacial
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            NomeEvento = reader.GetString(reader.GetOrdinal("NomeEvento")),
            TipoEvento = reader.GetString(reader.GetOrdinal("TipoEvento")),
            Localizacao = new LocalizacaoVo(
                reader.GetString(reader.GetOrdinal("Regiao")),
                reader.GetDecimal(reader.GetOrdinal("Latitude")),
                reader.GetDecimal(reader.GetOrdinal("Longitude"))),
            DataDeteccao = reader.GetDateTime(reader.GetOrdinal("DataDeteccao")),
            Intensidade = reader.GetInt32(reader.GetOrdinal("Intensidade")),
            NivelRisco = reader.GetInt32(reader.GetOrdinal("NivelRisco")),
            Classificacao = reader.GetString(reader.GetOrdinal("Classificacao")),
            SensorNome = reader.GetString(reader.GetOrdinal("SensorNome")),
            SensorTipo = reader.GetString(reader.GetOrdinal("SensorTipo")),
            ConfiabilidadeSensor = reader.GetDecimal(reader.GetOrdinal("ConfiabilidadeSensor")),
            Status = reader.GetString(reader.GetOrdinal("Status"))
        };
    }
}
