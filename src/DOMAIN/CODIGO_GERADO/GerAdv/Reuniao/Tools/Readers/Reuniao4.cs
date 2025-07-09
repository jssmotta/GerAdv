#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoReader
{
    ReuniaoResponse? Read(int id, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(Entity.DBReuniao dbRec, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(Entity.DBReuniao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(DBReuniao dbRec);
    ReuniaoResponseAll? ReadAll(DBReuniao dbRec, DataRow dr);
    ReuniaoResponseAll? ReadAll(DBReuniao dbRec, SqlDataReader dr);
    IEnumerable<ReuniaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Reuniao : IReuniaoReader
{
    public IEnumerable<ReuniaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ReuniaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ReuniaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<ReuniaoResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBReuniao(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Reuniao".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public ReuniaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoResponse? Read(Entity.DBReuniao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ReuniaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoResponse? Read(Entity.DBReuniao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
        return reuniao;
    }

    public ReuniaoResponse? Read(DBReuniao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
        return reuniao;
    }

    public ReuniaoResponseAll? ReadAll(DBReuniao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
        reuniao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return reuniao;
    }

    public ReuniaoResponseAll? ReadAll(DBReuniao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
        reuniao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return reuniao;
    }
}