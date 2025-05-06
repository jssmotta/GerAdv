#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INECompromissosReader
{
    NECompromissosResponse? Read(int id, SqlConnection oCnn);
    NECompromissosResponse? Read(string where, SqlConnection oCnn);
    NECompromissosResponse? Read(Entity.DBNECompromissos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    NECompromissosResponse? Read(DBNECompromissos dbRec);
}

public partial class NECompromissos : INECompromissosReader
{
    public NECompromissosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNECompromissos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NECompromissosResponse? Read(Entity.DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
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
        necompromissos.Auditor = auditor;
        return necompromissos;
    }

    public NECompromissosResponse? Read(DBNECompromissos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var necompromissos = new NECompromissosResponse
        {
            Id = dbRec.ID,
            PalavraChave = dbRec.FPalavraChave,
            Provisionar = dbRec.FProvisionar,
            TipoCompromisso = dbRec.FTipoCompromisso,
            TextoCompromisso = dbRec.FTextoCompromisso ?? string.Empty,
            Bold = dbRec.FBold,
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
        necompromissos.Auditor = auditor;
        return necompromissos;
    }
}