#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosReader
{
    ObjetosResponse? Read(int id, MsiSqlConnection oCnn);
    ObjetosResponse? Read(Entity.DBObjetos dbRec, MsiSqlConnection oCnn);
    ObjetosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ObjetosResponse? Read(Entity.DBObjetos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ObjetosResponse? Read(DBObjetos dbRec);
    ObjetosResponseAll? ReadAll(DBObjetos dbRec, DataRow dr);
    ObjetosResponseAll? ReadAll(DBObjetos dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ObjetosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Objetos : IObjetosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{ojtCodigo, ojtNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ObjetosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ObjetosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ObjetosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ObjetosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBObjetos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Objetos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ojtNome");
        }

        return query.ToString();
    }

    public ObjetosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(Entity.DBObjetos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ObjetosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ObjetosResponse? Read(Entity.DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return objetos;
    }

    public ObjetosResponse? Read(DBObjetos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return objetos;
    }

    public ObjetosResponseAll? ReadAll(DBObjetos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        objetos.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        objetos.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return objetos;
    }

    public ObjetosResponseAll? ReadAll(DBObjetos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var objetos = new ObjetosResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        objetos.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        objetos.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        return objetos;
    }
}