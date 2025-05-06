#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoReader
{
    AcaoResponse? Read(int id, SqlConnection oCnn);
    AcaoResponse? Read(string where, SqlConnection oCnn);
    AcaoResponse? Read(Entity.DBAcao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    AcaoResponse? Read(DBAcao dbRec);
}

public partial class Acao : IAcaoReader
{
    public AcaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAcao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AcaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAcao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AcaoResponse? Read(Entity.DBAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        acao.Auditor = auditor;
        return acao;
    }

    public AcaoResponse? Read(DBAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var acao = new AcaoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        acao.Auditor = auditor;
        return acao;
    }
}