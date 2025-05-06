#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProTipoBaixaReader
{
    ProTipoBaixaResponse? Read(int id, SqlConnection oCnn);
    ProTipoBaixaResponse? Read(string where, SqlConnection oCnn);
    ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec);
}

public partial class ProTipoBaixa : IProTipoBaixaReader
{
    public ProTipoBaixaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProTipoBaixa(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProTipoBaixaResponse? Read(Entity.DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
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
        protipobaixa.Auditor = auditor;
        return protipobaixa;
    }

    public ProTipoBaixaResponse? Read(DBProTipoBaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var protipobaixa = new ProTipoBaixaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
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
        protipobaixa.Auditor = auditor;
        return protipobaixa;
    }
}