#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoReader
{
    PoderJudiciarioAssociadoResponse? Read(int id, SqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(string where, SqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec);
    PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec);
}

public partial class PoderJudiciarioAssociado : IPoderJudiciarioAssociadoReader
{
    public PoderJudiciarioAssociadoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
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
        poderjudiciarioassociado.Auditor = auditor;
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
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
        poderjudiciarioassociado.Auditor = auditor;
        return poderjudiciarioassociado;
    }
}