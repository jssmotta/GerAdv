#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrecatoriaReader
{
    PrecatoriaResponse? Read(int id, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PrecatoriaResponse? Read(DBPrecatoria dbRec);
    PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, DataRow dr);
}

public partial class Precatoria : IPrecatoriaReader
{
    public PrecatoriaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPrecatoria(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PrecatoriaResponse? Read(Entity.DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        return precatoria;
    }

    public PrecatoriaResponse? Read(DBPrecatoria dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        return precatoria;
    }

    public PrecatoriaResponseAll? ReadAll(DBPrecatoria dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var precatoria = new PrecatoriaResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            PrecatoriaX = dbRec.FPrecatoria ?? string.Empty,
            Deprecante = dbRec.FDeprecante ?? string.Empty,
            Deprecado = dbRec.FDeprecado ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            precatoria.DtDist = dbRec.FDtDist;
        precatoria.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return precatoria;
    }
}