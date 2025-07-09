#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeReader
{
    CidadeResponse? Read(int id, MsiSqlConnection oCnn);
    CidadeResponse? Read(Entity.DBCidade dbRec, MsiSqlConnection oCnn);
    CidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CidadeResponse? Read(Entity.DBCidade dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CidadeResponse? Read(DBCidade dbRec);
    CidadeResponseAll? ReadAll(DBCidade dbRec, DataRow dr);
    CidadeResponseAll? ReadAll(DBCidade dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<CidadeResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Cidade : ICidadeReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{cidCodigo, cidNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<CidadeResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<CidadeResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<CidadeResponseAll>> ReadLocalAsync()
        {
            var result = new List<CidadeResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBCidade(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Cidade".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cidNome");
        }

        return query.ToString();
    }

    public CidadeResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CidadeResponse? Read(Entity.DBCidade dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public CidadeResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CidadeResponse? Read(Entity.DBCidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cidade;
    }

    public CidadeResponse? Read(DBCidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cidade;
    }

    public CidadeResponseAll? ReadAll(DBCidade dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponseAll
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        cidade.IDUF = dr["ufID"]?.ToString() ?? string.Empty;
        return cidade;
    }

    public CidadeResponseAll? ReadAll(DBCidade dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponseAll
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        cidade.IDUF = dr["ufID"]?.ToString() ?? string.Empty;
        return cidade;
    }
}