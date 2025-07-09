#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrecatoriaReader
{
    PrecatoriaResponse? Read(int id, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(DBPrecatoria dbRec);
    PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, DataRow dr);
    PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, SqlDataReader dr);
    IEnumerable<PrecatoriaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Precatoria : IPrecatoriaReader
{
    public IEnumerable<PrecatoriaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PrecatoriaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PrecatoriaResponseAll>> ReadLocalAsync()
        {
            var result = new List<PrecatoriaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPrecatoria(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Precatoria".dbo(oCnn)} (NOLOCK) ");
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

    public PrecatoriaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PrecatoriaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        return precatoria;
    }

    public PrecatoriaResponse? Read(DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        return precatoria;
    }

    public PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        precatoria.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return precatoria;
    }

    public PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        precatoria.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return precatoria;
    }
}