#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosReader
{
    ProResumosResponse? Read(int id, MsiSqlConnection oCnn);
    ProResumosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProResumosResponse? Read(Entity.DBProResumos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProResumosResponse? Read(DBProResumos dbRec);
    ProResumosResponseAll? ReadAll(DBProResumos dbRec, DataRow dr);
}

public partial class ProResumos : IProResumosReader
{
    public ProResumosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProResumosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProResumosResponse? Read(Entity.DBProResumos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        return proresumos;
    }

    public ProResumosResponse? Read(DBProResumos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        return proresumos;
    }

    public ProResumosResponseAll? ReadAll(DBProResumos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proresumos = new ProResumosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Resumo = dbRec.FResumo ?? string.Empty,
            TipoResumo = dbRec.FTipoResumo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proresumos.Data = dbRec.FData;
        proresumos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return proresumos;
    }
}