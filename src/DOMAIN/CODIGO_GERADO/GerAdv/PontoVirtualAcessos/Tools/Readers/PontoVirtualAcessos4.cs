#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualAcessosReader
{
    PontoVirtualAcessosResponse? Read(int id, MsiSqlConnection oCnn);
    PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec, MsiSqlConnection oCnn);
    PontoVirtualAcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec);
    PontoVirtualAcessosResponse? Read(DBPontoVirtualAcessos dbRec);
    PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, DataRow dr);
    PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, SqlDataReader dr);
    IEnumerable<PontoVirtualAcessosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PontoVirtualAcessos : IPontoVirtualAcessosReader
{
    public IEnumerable<PontoVirtualAcessosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PontoVirtualAcessosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PontoVirtualAcessosResponseAll>> ReadLocalAsync()
        {
            var result = new List<PontoVirtualAcessosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPontoVirtualAcessos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PontoVirtualAcessos".dbo(oCnn)} (NOLOCK) ");
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

    public PontoVirtualAcessosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtualAcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PontoVirtualAcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtualAcessos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        return pontovirtualacessos;
    }

    public PontoVirtualAcessosResponse? Read(DBPontoVirtualAcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        return pontovirtualacessos;
    }

    public PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        pontovirtualacessos.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtualacessos;
    }

    public PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        pontovirtualacessos.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtualacessos;
    }
}