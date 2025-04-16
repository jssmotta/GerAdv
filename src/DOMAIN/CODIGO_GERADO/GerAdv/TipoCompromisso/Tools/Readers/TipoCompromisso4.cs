#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoReader
{
    TipoCompromissoResponse? Read(int id, SqlConnection oCnn);
    TipoCompromissoResponse? Read(string where, SqlConnection oCnn);
    TipoCompromissoResponse? Read(Entity.DBTipoCompromisso dbRec);
    TipoCompromissoResponse? Read(DBTipoCompromisso dbRec);
}

public partial class TipoCompromisso : ITipoCompromissoReader
{
    public TipoCompromissoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoCompromissoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoCompromissoResponse? Read(Entity.DBTipoCompromisso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
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
        tipocompromisso.Auditor = auditor;
        return tipocompromisso;
    }

    public TipoCompromissoResponse? Read(DBTipoCompromisso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
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
        tipocompromisso.Auditor = auditor;
        return tipocompromisso;
    }
}