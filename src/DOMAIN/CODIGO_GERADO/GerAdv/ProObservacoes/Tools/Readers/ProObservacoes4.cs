#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesReader
{
    ProObservacoesResponse? Read(int id, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProObservacoesResponse? Read(DBProObservacoes dbRec);
    ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProObservacoes : IProObservacoesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) pobCodigo, pobNome FROM {"ProObservacoes".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}pobNome");
        }

        return query.ToString();
    }

    public ProObservacoesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        return proobservacoes;
    }

    public ProObservacoesResponse? Read(DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        return proobservacoes;
    }

    public ProObservacoesResponseAll? ReadAll(DBProObservacoes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        proobservacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proobservacoes;
    }
}