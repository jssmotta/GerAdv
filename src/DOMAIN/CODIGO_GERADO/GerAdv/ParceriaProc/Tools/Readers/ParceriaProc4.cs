#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParceriaProcReader
{
    ParceriaProcResponse? Read(int id, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ParceriaProcResponse? Read(DBParceriaProc dbRec);
    ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, DataRow dr);
}

public partial class ParceriaProc : IParceriaProcReader
{
    public ParceriaProcResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParceriaProc(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParceriaProcResponse? Read(Entity.DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return parceriaproc;
    }

    public ParceriaProcResponse? Read(DBParceriaProc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return parceriaproc;
    }

    public ParceriaProcResponseAll? ReadAll(DBParceriaProc dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parceriaproc = new ParceriaProcResponseAll
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Processo = dbRec.FProcesso,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        parceriaproc.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        parceriaproc.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return parceriaproc;
    }
}