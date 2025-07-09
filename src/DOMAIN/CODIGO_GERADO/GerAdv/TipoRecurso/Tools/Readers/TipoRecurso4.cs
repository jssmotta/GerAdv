#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoReader
{
    TipoRecursoResponse? Read(int id, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoRecursoResponse? Read(DBTipoRecurso dbRec);
    TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, DataRow dr);
    TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TipoRecursoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoRecurso : ITipoRecursoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{trcCodigo, trcDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TipoRecursoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TipoRecursoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TipoRecursoResponseAll>> ReadLocalAsync()
        {
            var result = new List<TipoRecursoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTipoRecurso(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TipoRecurso".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}trcDescricao");
        }

        return query.ToString();
    }

    public TipoRecursoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TipoRecursoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiporecurso;
    }

    public TipoRecursoResponse? Read(DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tiporecurso;
    }

    public TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        tiporecurso.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        tiporecurso.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return tiporecurso;
    }

    public TipoRecursoResponseAll? ReadAll(DBTipoRecurso dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        tiporecurso.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        tiporecurso.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return tiporecurso;
    }
}