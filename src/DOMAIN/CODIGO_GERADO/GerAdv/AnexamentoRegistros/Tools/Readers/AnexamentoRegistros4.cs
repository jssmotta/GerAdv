#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAnexamentoRegistrosReader
{
    AnexamentoRegistrosResponse? Read(int id, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec);
    AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, DataRow dr);
    AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, SqlDataReader dr);
    IEnumerable<AnexamentoRegistrosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AnexamentoRegistros : IAnexamentoRegistrosReader
{
    public IEnumerable<AnexamentoRegistrosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AnexamentoRegistrosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AnexamentoRegistrosResponseAll>> ReadLocalAsync()
        {
            var result = new List<AnexamentoRegistrosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAnexamentoRegistros(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AnexamentoRegistros".dbo(oCnn)} (NOLOCK) ");
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

    public AnexamentoRegistrosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        anexamentoregistros.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        anexamentoregistros.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return anexamentoregistros;
    }
}