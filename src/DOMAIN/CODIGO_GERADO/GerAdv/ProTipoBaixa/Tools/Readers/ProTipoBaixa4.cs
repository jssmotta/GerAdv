#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProTipoBaixaReader
{
    ProTipoBaixaResponse? Read(int id, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec);
    ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, DataRow dr);
    ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ProTipoBaixaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProTipoBaixa : IProTipoBaixaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{ptxCodigo, ptxNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ProTipoBaixaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProTipoBaixaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProTipoBaixaResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProTipoBaixaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProTipoBaixa(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProTipoBaixa".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ptxNome");
        }

        return query.ToString();
    }

    public ProTipoBaixaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }

    public ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }

    public ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }

    public ProTipoBaixaResponseAll? ReadAll(DBProTipoBaixa dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return protipobaixa;
    }
}