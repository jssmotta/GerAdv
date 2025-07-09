#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasCliReader
{
    GruposEmpresasCliResponse? Read(int id, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec);
    GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, DataRow dr);
    GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, SqlDataReader dr);
    IEnumerable<GruposEmpresasCliResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GruposEmpresasCli : IGruposEmpresasCliReader
{
    public IEnumerable<GruposEmpresasCliResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GruposEmpresasCliResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GruposEmpresasCliResponseAll>> ReadLocalAsync()
        {
            var result = new List<GruposEmpresasCliResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGruposEmpresasCli(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GruposEmpresasCli".dbo(oCnn)} (NOLOCK) ");
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

    public GruposEmpresasCliResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        return gruposempresascli;
    }

    public GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        return gruposempresascli;
    }

    public GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponseAll
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        gruposempresascli.DescricaoGruposEmpresas = dr["grpDescricao"]?.ToString() ?? string.Empty;
        gruposempresascli.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return gruposempresascli;
    }

    public GruposEmpresasCliResponseAll? ReadAll(DBGruposEmpresasCli dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponseAll
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
        };
        gruposempresascli.DescricaoGruposEmpresas = dr["grpDescricao"]?.ToString() ?? string.Empty;
        gruposempresascli.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return gruposempresascli;
    }
}