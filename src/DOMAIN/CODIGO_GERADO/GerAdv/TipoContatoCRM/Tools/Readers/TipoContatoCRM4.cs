#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoContatoCRMReader
{
    TipoContatoCRMResponse? Read(int id, SqlConnection oCnn);
    TipoContatoCRMResponse? Read(string where, SqlConnection oCnn);
    TipoContatoCRMResponse? Read(Entity.DBTipoContatoCRM dbRec);
    TipoContatoCRMResponse? Read(DBTipoContatoCRM dbRec);
}

public partial class TipoContatoCRM : ITipoContatoCRMReader
{
    public TipoContatoCRMResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoContatoCRM(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoContatoCRMResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoContatoCRM(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoContatoCRMResponse? Read(Entity.DBTipoContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocontatocrm = new TipoContatoCRMResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        tipocontatocrm.Auditor = auditor;
        return tipocontatocrm;
    }

    public TipoContatoCRMResponse? Read(DBTipoContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocontatocrm = new TipoContatoCRMResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        tipocontatocrm.Auditor = auditor;
        return tipocontatocrm;
    }
}