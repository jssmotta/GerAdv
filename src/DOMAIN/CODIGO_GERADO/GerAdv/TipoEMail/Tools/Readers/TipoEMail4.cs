#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailReader
{
    TipoEMailResponse? Read(int id, MsiSqlConnection oCnn);
    TipoEMailResponse? Read(Entity.DBTipoEMail dbRec, MsiSqlConnection oCnn);
    TipoEMailResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TipoEMailResponse? Read(Entity.DBTipoEMail dbRec);
    TipoEMailResponse? Read(DBTipoEMail dbRec);
    TipoEMailResponseAll? ReadAll(DBTipoEMail dbRec, DataRow dr);
    TipoEMailResponseAll? ReadAll(DBTipoEMail dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TipoEMailResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TipoEMail : ITipoEMailReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{tmlCodigo, tmlNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TipoEMailResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TipoEMailResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TipoEMailResponseAll>> ReadLocalAsync()
        {
            var result = new List<TipoEMailResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTipoEMail(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TipoEMail".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}tmlNome");
        }

        return query.ToString();
    }

    public TipoEMailResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEMail(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEMailResponse? Read(Entity.DBTipoEMail dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TipoEMailResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEMail(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEMailResponse? Read(Entity.DBTipoEMail dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }

    public TipoEMailResponse? Read(DBTipoEMail dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }

    public TipoEMailResponseAll? ReadAll(DBTipoEMail dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }

    public TipoEMailResponseAll? ReadAll(DBTipoEMail dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }
}