#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaReader
{
    EnquadramentoEmpresaResponse? Read(int id, MsiSqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(Entity.DBEnquadramentoEmpresa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(DBEnquadramentoEmpresa dbRec);
    EnquadramentoEmpresaResponseAll? ReadAll(DBEnquadramentoEmpresa dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EnquadramentoEmpresa : IEnquadramentoEmpresaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) eqeCodigo, eqeNome FROM {"EnquadramentoEmpresa".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}eqeNome");
        }

        return query.ToString();
    }

    public EnquadramentoEmpresaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnquadramentoEmpresaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnquadramentoEmpresaResponse? Read(Entity.DBEnquadramentoEmpresa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enquadramentoempresa = new EnquadramentoEmpresaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enquadramentoempresa;
    }

    public EnquadramentoEmpresaResponse? Read(DBEnquadramentoEmpresa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enquadramentoempresa = new EnquadramentoEmpresaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enquadramentoempresa;
    }

    public EnquadramentoEmpresaResponseAll? ReadAll(DBEnquadramentoEmpresa dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enquadramentoempresa = new EnquadramentoEmpresaResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enquadramentoempresa;
    }
}