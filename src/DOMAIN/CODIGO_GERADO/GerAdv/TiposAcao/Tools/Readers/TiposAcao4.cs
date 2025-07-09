#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITiposAcaoReader
{
    TiposAcaoResponse? Read(int id, MsiSqlConnection oCnn);
    TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec, MsiSqlConnection oCnn);
    TiposAcaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TiposAcaoResponse? Read(DBTiposAcao dbRec);
    TiposAcaoResponseAll? ReadAll(DBTiposAcao dbRec, DataRow dr);
    TiposAcaoResponseAll? ReadAll(DBTiposAcao dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TiposAcaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TiposAcao : ITiposAcaoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{tacCodigo, tacNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TiposAcaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TiposAcaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TiposAcaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<TiposAcaoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTiposAcao(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TiposAcao".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tacNome");
        }

        return query.ToString();
    }

    public TiposAcaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTiposAcao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TiposAcaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTiposAcao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiposacao;
    }

    public TiposAcaoResponse? Read(DBTiposAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiposacao;
    }

    public TiposAcaoResponseAll? ReadAll(DBTiposAcao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiposacao;
    }

    public TiposAcaoResponseAll? ReadAll(DBTiposAcao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiposacao;
    }
}