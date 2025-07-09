#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosReader
{
    ProResumosResponse? Read(int id, MsiSqlConnection oCnn);
    ProResumosResponse? Read(Entity.DBProResumos dbRec, MsiSqlConnection oCnn);
    ProResumosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProResumosResponse? Read(Entity.DBProResumos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProResumosResponse? Read(DBProResumos dbRec);
    ProResumosResponseAll? ReadAll(DBProResumos dbRec, DataRow dr);
    ProResumosResponseAll? ReadAll(DBProResumos dbRec, SqlDataReader dr);
    IEnumerable<ProResumosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProResumos : IProResumosReader
{
    public IEnumerable<ProResumosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProResumosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProResumosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProResumosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProResumos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProResumos".dbo(oCnn)} (NOLOCK) ");
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

    public ProResumosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProResumosResponse? Read(Entity.DBProResumos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProResumosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProResumosResponse? Read(Entity.DBProResumos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        return proresumos;
    }

    public ProResumosResponse? Read(DBProResumos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        return proresumos;
    }

    public ProResumosResponseAll? ReadAll(DBProResumos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        proresumos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proresumos;
    }

    public ProResumosResponseAll? ReadAll(DBProResumos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        proresumos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proresumos;
    }
}