#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuReader
{
    StatusBiuResponse? Read(int id, MsiSqlConnection oCnn);
    StatusBiuResponse? Read(Entity.DBStatusBiu dbRec, MsiSqlConnection oCnn);
    StatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    StatusBiuResponse? Read(Entity.DBStatusBiu dbRec);
    StatusBiuResponse? Read(DBStatusBiu dbRec);
    StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, DataRow dr);
    StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<StatusBiuResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class StatusBiu : IStatusBiuReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{stbCodigo, stbNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<StatusBiuResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<StatusBiuResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<StatusBiuResponseAll>> ReadLocalAsync()
        {
            var result = new List<StatusBiuResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBStatusBiu(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"StatusBiu".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}stbNome");
        }

        return query.ToString();
    }

    public StatusBiuResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(Entity.DBStatusBiu dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public StatusBiuResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusBiuResponse? Read(Entity.DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }

    public StatusBiuResponse? Read(DBStatusBiu dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }

    public StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        statusbiu.NomeTipoStatusBiu = dr["tsbNome"]?.ToString() ?? string.Empty;
        statusbiu.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return statusbiu;
    }

    public StatusBiuResponseAll? ReadAll(DBStatusBiu dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusbiu = new StatusBiuResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        statusbiu.NomeTipoStatusBiu = dr["tsbNome"]?.ToString() ?? string.Empty;
        statusbiu.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return statusbiu;
    }
}