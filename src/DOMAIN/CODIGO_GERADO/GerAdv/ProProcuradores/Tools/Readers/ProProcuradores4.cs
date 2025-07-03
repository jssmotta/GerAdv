#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProProcuradoresReader
{
    ProProcuradoresResponse? Read(int id, MsiSqlConnection oCnn);
    ProProcuradoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProProcuradoresResponse? Read(Entity.DBProProcuradores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProProcuradoresResponse? Read(DBProProcuradores dbRec);
    ProProcuradoresResponseAll? ReadAll(DBProProcuradores dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProProcuradores : IProProcuradoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) papCodigo, papNome FROM {"ProProcuradores".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}papNome");
        }

        return query.ToString();
    }

    public ProProcuradoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProProcuradores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProProcuradoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProProcuradores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProProcuradoresResponse? Read(Entity.DBProProcuradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proprocuradores = new ProProcuradoresResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Substabelecimento = dbRec.FSubstabelecimento,
            Procuracao = dbRec.FProcuracao,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proprocuradores.Data = dbRec.FData;
        return proprocuradores;
    }

    public ProProcuradoresResponse? Read(DBProProcuradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proprocuradores = new ProProcuradoresResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Substabelecimento = dbRec.FSubstabelecimento,
            Procuracao = dbRec.FProcuracao,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proprocuradores.Data = dbRec.FData;
        return proprocuradores;
    }

    public ProProcuradoresResponseAll? ReadAll(DBProProcuradores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proprocuradores = new ProProcuradoresResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Substabelecimento = dbRec.FSubstabelecimento,
            Procuracao = dbRec.FProcuracao,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proprocuradores.Data = dbRec.FData;
        proprocuradores.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        proprocuradores.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proprocuradores;
    }
}