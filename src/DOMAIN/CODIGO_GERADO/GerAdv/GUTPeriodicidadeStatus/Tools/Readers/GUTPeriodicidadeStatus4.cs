#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusReader
{
    GUTPeriodicidadeStatusResponse? Read(int id, SqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(string where, SqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec);
}

public partial class GUTPeriodicidadeStatus : IGUTPeriodicidadeStatusReader
{
    public GUTPeriodicidadeStatusResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
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
        gutperiodicidadestatus.Auditor = auditor;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
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
        gutperiodicidadestatus.Auditor = auditor;
        return gutperiodicidadestatus;
    }
}