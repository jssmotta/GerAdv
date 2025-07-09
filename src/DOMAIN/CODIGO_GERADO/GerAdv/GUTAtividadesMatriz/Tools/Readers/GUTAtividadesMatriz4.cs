#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizReader
{
    GUTAtividadesMatrizResponse? Read(int id, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec);
    GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, DataRow dr);
    GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, SqlDataReader dr);
    IEnumerable<GUTAtividadesMatrizResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTAtividadesMatriz : IGUTAtividadesMatrizReader
{
    public IEnumerable<GUTAtividadesMatrizResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GUTAtividadesMatrizResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GUTAtividadesMatrizResponseAll>> ReadLocalAsync()
        {
            var result = new List<GUTAtividadesMatrizResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGUTAtividadesMatriz(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GUTAtividadesMatriz".dbo(oCnn)} (NOLOCK) ");
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

    public GUTAtividadesMatrizResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividadesMatriz(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesMatrizResponse? Read(Entity.DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponse? Read(DBGUTAtividadesMatriz dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponse
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponseAll
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        gutatividadesmatriz.DescricaoGUTMatriz = dr["gutDescricao"]?.ToString() ?? string.Empty;
        gutatividadesmatriz.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutatividadesmatriz;
    }

    public GUTAtividadesMatrizResponseAll? ReadAll(DBGUTAtividadesMatriz dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividadesmatriz = new GUTAtividadesMatrizResponseAll
        {
            Id = dbRec.ID,
            GUTMatriz = dbRec.FGUTMatriz,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        gutatividadesmatriz.DescricaoGUTMatriz = dr["gutDescricao"]?.ToString() ?? string.Empty;
        gutatividadesmatriz.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutatividadesmatriz;
    }
}