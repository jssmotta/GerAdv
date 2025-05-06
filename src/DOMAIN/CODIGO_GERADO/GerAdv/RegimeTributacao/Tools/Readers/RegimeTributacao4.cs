#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoReader
{
    RegimeTributacaoResponse? Read(int id, SqlConnection oCnn);
    RegimeTributacaoResponse? Read(string where, SqlConnection oCnn);
    RegimeTributacaoResponse? Read(Entity.DBRegimeTributacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    RegimeTributacaoResponse? Read(DBRegimeTributacao dbRec);
}

public partial class RegimeTributacao : IRegimeTributacaoReader
{
    public RegimeTributacaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RegimeTributacaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RegimeTributacaoResponse? Read(Entity.DBRegimeTributacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        regimetributacao.Auditor = auditor;
        return regimetributacao;
    }

    public RegimeTributacaoResponse? Read(DBRegimeTributacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        regimetributacao.Auditor = auditor;
        return regimetributacao;
    }
}