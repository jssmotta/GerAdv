#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusReader
{
    GUTPeriodicidadeStatusResponse? Read(int id, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec);
    GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, DataRow dr);
    GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, SqlDataReader dr);
    IEnumerable<GUTPeriodicidadeStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTPeriodicidadeStatus : IGUTPeriodicidadeStatusReader
{
    public IEnumerable<GUTPeriodicidadeStatusResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GUTPeriodicidadeStatusResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GUTPeriodicidadeStatusResponseAll>> ReadLocalAsync()
        {
            var result = new List<GUTPeriodicidadeStatusResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGUTPeriodicidadeStatus(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GUTPeriodicidadeStatus".dbo(oCnn)} (NOLOCK) ");
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

    public GUTPeriodicidadeStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponseAll
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        gutperiodicidadestatus.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponseAll
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        gutperiodicidadestatus.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutperiodicidadestatus;
    }
}