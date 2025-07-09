#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoReader
{
    SituacaoResponse? Read(int id, MsiSqlConnection oCnn);
    SituacaoResponse? Read(Entity.DBSituacao dbRec, MsiSqlConnection oCnn);
    SituacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SituacaoResponse? Read(Entity.DBSituacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SituacaoResponse? Read(DBSituacao dbRec);
    SituacaoResponseAll? ReadAll(DBSituacao dbRec, DataRow dr);
    SituacaoResponseAll? ReadAll(DBSituacao dbRec, SqlDataReader dr);
    IEnumerable<SituacaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Situacao : ISituacaoReader
{
    public IEnumerable<SituacaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<SituacaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<SituacaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<SituacaoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBSituacao(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Situacao".dbo(oCnn)} (NOLOCK) ");
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

    public SituacaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(Entity.DBSituacao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public SituacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(Entity.DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }

    public SituacaoResponse? Read(DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }

    public SituacaoResponseAll? ReadAll(DBSituacao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponseAll
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }

    public SituacaoResponseAll? ReadAll(DBSituacao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponseAll
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }
}