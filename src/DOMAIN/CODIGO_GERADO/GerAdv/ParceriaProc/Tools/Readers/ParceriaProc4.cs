#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcReader
{
    ParceriaProcResponse? Read(int id, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(DBParceriaProc dbRec);
    ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, DataRow dr);
    ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, SqlDataReader dr);
    IEnumerable<ParceriaProcResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ParceriaProc : IParceriaProcReader
{
    public IEnumerable<ParceriaProcResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ParceriaProcResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ParceriaProcResponseAll>> ReadLocalAsync()
        {
            var result = new List<ParceriaProcResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBParceriaProc(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ParceriaProc".dbo(oCnn)} (NOLOCK) ");
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

    public ParceriaProcResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ParceriaProcResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return parceriaproc;
    }

    public ParceriaProcResponse? Read(DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return parceriaproc;
    }

    public ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        parceriaproc.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        parceriaproc.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parceriaproc;
    }

    public ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        parceriaproc.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        parceriaproc.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parceriaproc;
    }
}