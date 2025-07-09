#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoReader
{
    AcaoResponse? Read(int id, MsiSqlConnection oCnn);
    AcaoResponse? Read(Entity.DBAcao dbRec, MsiSqlConnection oCnn);
    AcaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AcaoResponse? Read(Entity.DBAcao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AcaoResponse? Read(DBAcao dbRec);
    AcaoResponseAll? ReadAll(DBAcao dbRec, DataRow dr);
    AcaoResponseAll? ReadAll(DBAcao dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<AcaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Acao : IAcaoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{acaCodigo, acaDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<AcaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AcaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AcaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<AcaoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAcao(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Acao".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}acaDescricao");
        }

        return query.ToString();
    }

    public AcaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAcao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AcaoResponse? Read(Entity.DBAcao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AcaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAcao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AcaoResponse? Read(Entity.DBAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return acao;
    }

    public AcaoResponse? Read(DBAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return acao;
    }

    public AcaoResponseAll? ReadAll(DBAcao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        acao.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        acao.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return acao;
    }

    public AcaoResponseAll? ReadAll(DBAcao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        acao.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        acao.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return acao;
    }
}