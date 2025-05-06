#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorReader
{
    SetorResponse? Read(int id, SqlConnection oCnn);
    SetorResponse? Read(string where, SqlConnection oCnn);
    SetorResponse? Read(Entity.DBSetor dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    SetorResponse? Read(DBSetor dbRec);
}

public partial class Setor : ISetorReader
{
    public SetorResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SetorResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SetorResponse? Read(Entity.DBSetor dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var setor = new SetorResponse
        {
            Id = dbRec.ID,
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
        setor.Auditor = auditor;
        return setor;
    }

    public SetorResponse? Read(DBSetor dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var setor = new SetorResponse
        {
            Id = dbRec.ID,
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
        setor.Auditor = auditor;
        return setor;
    }
}