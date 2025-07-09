#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasReader
{
    GruposEmpresasResponse? Read(int id, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(DBGruposEmpresas dbRec);
    GruposEmpresasResponseAll? ReadAll(DBGruposEmpresas dbRec, DataRow dr);
    GruposEmpresasResponseAll? ReadAll(DBGruposEmpresas dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<GruposEmpresasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GruposEmpresas : IGruposEmpresasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{grpCodigo, grpDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<GruposEmpresasResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GruposEmpresasResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GruposEmpresasResponseAll>> ReadLocalAsync()
        {
            var result = new List<GruposEmpresasResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGruposEmpresas(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GruposEmpresas".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}grpDescricao");
        }

        return query.ToString();
    }

    public GruposEmpresasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GruposEmpresasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresas = new GruposEmpresasResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gruposempresas;
    }

    public GruposEmpresasResponse? Read(DBGruposEmpresas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresas = new GruposEmpresasResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gruposempresas;
    }

    public GruposEmpresasResponseAll? ReadAll(DBGruposEmpresas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresas = new GruposEmpresasResponseAll
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        gruposempresas.NomeOponentes = dr["opoNome"]?.ToString() ?? string.Empty;
        gruposempresas.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return gruposempresas;
    }

    public GruposEmpresasResponseAll? ReadAll(DBGruposEmpresas dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresas = new GruposEmpresasResponseAll
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        gruposempresas.NomeOponentes = dr["opoNome"]?.ToString() ?? string.Empty;
        gruposempresas.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return gruposempresas;
    }
}