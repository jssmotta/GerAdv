#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDReader
{
    AndamentosMDResponse? Read(int id, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(DBAndamentosMD dbRec);
    AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, DataRow dr);
    AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<AndamentosMDResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AndamentosMD : IAndamentosMDReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{amdCodigo, amdNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<AndamentosMDResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AndamentosMDResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AndamentosMDResponseAll>> ReadLocalAsync()
        {
            var result = new List<AndamentosMDResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAndamentosMD(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AndamentosMD".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}amdNome");
        }

        return query.ToString();
    }

    public AndamentosMDResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AndamentosMDResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return andamentosmd;
    }

    public AndamentosMDResponse? Read(DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return andamentosmd;
    }

    public AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        andamentosmd.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return andamentosmd;
    }

    public AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        andamentosmd.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return andamentosmd;
    }
}