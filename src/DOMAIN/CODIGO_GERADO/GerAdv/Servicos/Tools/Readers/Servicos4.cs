#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosReader
{
    ServicosResponse? Read(int id, MsiSqlConnection oCnn);
    ServicosResponse? Read(Entity.DBServicos dbRec, MsiSqlConnection oCnn);
    ServicosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ServicosResponse? Read(Entity.DBServicos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ServicosResponse? Read(DBServicos dbRec);
    ServicosResponseAll? ReadAll(DBServicos dbRec, DataRow dr);
    ServicosResponseAll? ReadAll(DBServicos dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ServicosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Servicos : IServicosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{serCodigo, serDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ServicosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ServicosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ServicosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ServicosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBServicos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Servicos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}serDescricao");
        }

        return query.ToString();
    }

    public ServicosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(Entity.DBServicos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ServicosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(Entity.DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }

    public ServicosResponse? Read(DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }

    public ServicosResponseAll? ReadAll(DBServicos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponseAll
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }

    public ServicosResponseAll? ReadAll(DBServicos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponseAll
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }
}