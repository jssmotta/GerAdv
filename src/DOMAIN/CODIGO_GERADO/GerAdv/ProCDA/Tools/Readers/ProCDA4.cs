#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAReader
{
    ProCDAResponse? Read(int id, MsiSqlConnection oCnn);
    ProCDAResponse? Read(Entity.DBProCDA dbRec, MsiSqlConnection oCnn);
    ProCDAResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProCDAResponse? Read(Entity.DBProCDA dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProCDAResponse? Read(DBProCDA dbRec);
    ProCDAResponseAll? ReadAll(DBProCDA dbRec, DataRow dr);
    ProCDAResponseAll? ReadAll(DBProCDA dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ProCDAResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProCDA : IProCDAReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{pcdCodigo, pcdNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ProCDAResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProCDAResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProCDAResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProCDAResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProCDA(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProCDA".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}pcdNome");
        }

        return query.ToString();
    }

    public ProCDAResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(Entity.DBProCDA dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProCDAResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProCDAResponse? Read(Entity.DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return procda;
    }

    public ProCDAResponse? Read(DBProCDA dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return procda;
    }

    public ProCDAResponseAll? ReadAll(DBProCDA dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        procda.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return procda;
    }

    public ProCDAResponseAll? ReadAll(DBProCDA dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var procda = new ProCDAResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        procda.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return procda;
    }
}