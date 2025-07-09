#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscReader
{
    CargosEscResponse? Read(int id, MsiSqlConnection oCnn);
    CargosEscResponse? Read(Entity.DBCargosEsc dbRec, MsiSqlConnection oCnn);
    CargosEscResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscResponse? Read(Entity.DBCargosEsc dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    CargosEscResponse? Read(DBCargosEsc dbRec);
    CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, DataRow dr);
    CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<CargosEscResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class CargosEsc : ICargosEscReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{cgeCodigo, cgeNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<CargosEscResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<CargosEscResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<CargosEscResponseAll>> ReadLocalAsync()
        {
            var result = new List<CargosEscResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBCargosEsc(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"CargosEsc".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cgeNome");
        }

        return query.ToString();
    }

    public CargosEscResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(Entity.DBCargosEsc dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public CargosEscResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(Entity.DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }

    public CargosEscResponse? Read(DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }

    public CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponseAll
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }

    public CargosEscResponseAll? ReadAll(DBCargosEsc dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponseAll
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }
}