#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualReader
{
    PontoVirtualResponse? Read(int id, MsiSqlConnection oCnn);
    PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec, MsiSqlConnection oCnn);
    PontoVirtualResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec);
    PontoVirtualResponse? Read(DBPontoVirtual dbRec);
    PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, DataRow dr);
    PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, SqlDataReader dr);
    IEnumerable<PontoVirtualResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PontoVirtual : IPontoVirtualReader
{
    public IEnumerable<PontoVirtualResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PontoVirtualResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PontoVirtualResponseAll>> ReadLocalAsync()
        {
            var result = new List<PontoVirtualResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPontoVirtual(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PontoVirtual".dbo(oCnn)} (NOLOCK) ");
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

    public PontoVirtualResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PontoVirtualResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        return pontovirtual;
    }

    public PontoVirtualResponse? Read(DBPontoVirtual dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        return pontovirtual;
    }

    public PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        pontovirtual.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtual;
    }

    public PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        pontovirtual.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtual;
    }
}