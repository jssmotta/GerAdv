#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFReader
{
    UFResponse? Read(int id, MsiSqlConnection oCnn);
    UFResponse? Read(Entity.DBUF dbRec, MsiSqlConnection oCnn);
    UFResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    UFResponse? Read(Entity.DBUF dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    UFResponse? Read(DBUF dbRec);
    UFResponseAll? ReadAll(DBUF dbRec, DataRow dr);
    UFResponseAll? ReadAll(DBUF dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<UFResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class UF : IUFReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{ufCodigo, ufID}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<UFResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<UFResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<UFResponseAll>> ReadLocalAsync()
        {
            var result = new List<UFResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBUF(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"UF".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ufID");
        }

        return query.ToString();
    }

    public UFResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(Entity.DBUF dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public UFResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UFResponse? Read(Entity.DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return uf;
    }

    public UFResponse? Read(DBUF dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return uf;
    }

    public UFResponseAll? ReadAll(DBUF dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponseAll
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        uf.NomePaises = dr["paiNome"]?.ToString() ?? string.Empty;
        return uf;
    }

    public UFResponseAll? ReadAll(DBUF dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var uf = new UFResponseAll
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        uf.NomePaises = dr["paiNome"]?.ToString() ?? string.Empty;
        return uf;
    }
}