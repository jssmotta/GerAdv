#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassReader
{
    CargosEscClassResponse? Read(int id, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscClassResponse? Read(DBCargosEscClass dbRec);
    CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, DataRow dr);
    CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<CargosEscClassResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class CargosEscClass : ICargosEscClassReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{cecCodigo, cecNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<CargosEscClassResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<CargosEscClassResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<CargosEscClassResponseAll>> ReadLocalAsync()
        {
            var result = new List<CargosEscClassResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBCargosEscClass(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"CargosEscClass".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cecNome");
        }

        return query.ToString();
    }

    public CargosEscClassResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public CargosEscClassResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscClassResponse? Read(Entity.DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }

    public CargosEscClassResponse? Read(DBCargosEscClass dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }

    public CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }

    public CargosEscClassResponseAll? ReadAll(DBCargosEscClass dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosescclass = new CargosEscClassResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }
}