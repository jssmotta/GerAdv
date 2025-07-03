#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasReader
{
    GruposEmpresasResponse? Read(int id, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GruposEmpresasResponse? Read(DBGruposEmpresas dbRec);
    GruposEmpresasResponseAll? ReadAll(DBGruposEmpresas dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GruposEmpresas : IGruposEmpresasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) grpCodigo, grpDescricao FROM {"GruposEmpresas".dbo(oCnn)} (NOLOCK) ");
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
}