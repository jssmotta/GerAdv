#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMViewReader
{
    ContatoCRMViewResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec, MsiSqlConnection oCnn);
    ContatoCRMViewResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec);
    ContatoCRMViewResponse? Read(DBContatoCRMView dbRec);
    ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, DataRow dr);
    ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, SqlDataReader dr);
    IEnumerable<ContatoCRMViewResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ContatoCRMView : IContatoCRMViewReader
{
    public IEnumerable<ContatoCRMViewResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ContatoCRMViewResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ContatoCRMViewResponseAll>> ReadLocalAsync()
        {
            var result = new List<ContatoCRMViewResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBContatoCRMView(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ContatoCRMView".dbo(oCnn)} (NOLOCK) ");
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

    public ContatoCRMViewResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMView(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMViewResponse? Read(Entity.DBContatoCRMView dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponse
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }

    public ContatoCRMViewResponse? Read(DBContatoCRMView dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponse
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }

    public ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponseAll
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }

    public ContatoCRMViewResponseAll? ReadAll(DBContatoCRMView dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmview = new ContatoCRMViewResponseAll
        {
            Id = dbRec.ID,
            CGUID = dbRec.FCGUID ?? string.Empty,
            IP = dbRec.FIP ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrmview.Data = dbRec.FData;
        return contatocrmview;
    }
}