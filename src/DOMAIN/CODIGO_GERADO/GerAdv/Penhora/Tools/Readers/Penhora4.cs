#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraReader
{
    PenhoraResponse? Read(int id, MsiSqlConnection oCnn);
    PenhoraResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraResponse? Read(Entity.DBPenhora dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraResponse? Read(DBPenhora dbRec);
    PenhoraResponseAll? ReadAll(DBPenhora dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Penhora : IPenhoraReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) phrCodigo, phrNome FROM {"Penhora".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}phrNome");
        }

        return query.ToString();
    }

    public PenhoraResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(Entity.DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        return penhora;
    }

    public PenhoraResponse? Read(DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        return penhora;
    }

    public PenhoraResponseAll? ReadAll(DBPenhora dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        penhora.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        penhora.NomePenhoraStatus = dr["phsNome"]?.ToString() ?? string.Empty;
        return penhora;
    }
}