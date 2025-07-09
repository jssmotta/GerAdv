#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesReader
{
    AtividadesResponse? Read(int id, MsiSqlConnection oCnn);
    AtividadesResponse? Read(Entity.DBAtividades dbRec, MsiSqlConnection oCnn);
    AtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AtividadesResponse? Read(Entity.DBAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AtividadesResponse? Read(DBAtividades dbRec);
    AtividadesResponseAll? ReadAll(DBAtividades dbRec, DataRow dr);
    AtividadesResponseAll? ReadAll(DBAtividades dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<AtividadesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Atividades : IAtividadesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{atvCodigo, atvDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<AtividadesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AtividadesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AtividadesResponseAll>> ReadLocalAsync()
        {
            var result = new List<AtividadesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAtividades(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Atividades".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}atvDescricao");
        }

        return query.ToString();
    }

    public AtividadesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(Entity.DBAtividades dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(Entity.DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }

    public AtividadesResponse? Read(DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }

    public AtividadesResponseAll? ReadAll(DBAtividades dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }

    public AtividadesResponseAll? ReadAll(DBAtividades dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }
}