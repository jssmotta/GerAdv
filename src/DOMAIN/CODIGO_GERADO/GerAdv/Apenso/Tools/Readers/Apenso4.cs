#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApensoReader
{
    ApensoResponse? Read(int id, MsiSqlConnection oCnn);
    ApensoResponse? Read(Entity.DBApenso dbRec, MsiSqlConnection oCnn);
    ApensoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ApensoResponse? Read(Entity.DBApenso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ApensoResponse? Read(DBApenso dbRec);
    ApensoResponseAll? ReadAll(DBApenso dbRec, DataRow dr);
    ApensoResponseAll? ReadAll(DBApenso dbRec, SqlDataReader dr);
    IEnumerable<ApensoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Apenso : IApensoReader
{
    public IEnumerable<ApensoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ApensoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ApensoResponseAll>> ReadLocalAsync()
        {
            var result = new List<ApensoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBApenso(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Apenso".dbo(oCnn)} (NOLOCK) ");
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

    public ApensoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(Entity.DBApenso dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ApensoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(Entity.DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        return apenso;
    }

    public ApensoResponse? Read(DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        return apenso;
    }

    public ApensoResponseAll? ReadAll(DBApenso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        apenso.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso;
    }

    public ApensoResponseAll? ReadAll(DBApenso dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        apenso.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso;
    }
}