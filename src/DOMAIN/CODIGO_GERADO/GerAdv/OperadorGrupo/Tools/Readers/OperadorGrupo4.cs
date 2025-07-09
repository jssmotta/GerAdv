#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGrupoReader
{
    OperadorGrupoResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(DBOperadorGrupo dbRec);
    OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, DataRow dr);
    OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, SqlDataReader dr);
    IEnumerable<OperadorGrupoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGrupo : IOperadorGrupoReader
{
    public IEnumerable<OperadorGrupoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadorGrupoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadorGrupoResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadorGrupoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadorGrupo(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OperadorGrupo".dbo(oCnn)} (NOLOCK) ");
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

    public OperadorGrupoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadorGrupoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        return operadorgrupo;
    }

    public OperadorGrupoResponse? Read(DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        return operadorgrupo;
    }

    public OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        operadorgrupo.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgrupo;
    }

    public OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        operadorgrupo.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgrupo;
    }
}