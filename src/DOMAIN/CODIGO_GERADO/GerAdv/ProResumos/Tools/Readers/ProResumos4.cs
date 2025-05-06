#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProResumosReader
{
    ProResumosResponse? Read(int id, SqlConnection oCnn);
    ProResumosResponse? Read(string where, SqlConnection oCnn);
    ProResumosResponse? Read(Entity.DBProResumos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProResumosResponse? Read(DBProResumos dbRec);
}

public partial class ProResumos : IProResumosReader
{
    public ProResumosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProResumosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProResumos(sqlWhere: where, oCnn: oCnn);
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
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        proresumos.Auditor = auditor;
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
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        proresumos.Auditor = auditor;
        return proresumos;
    }
}