#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensReader
{
    DocsRecebidosItensResponse? Read(int id, SqlConnection oCnn);
    DocsRecebidosItensResponse? Read(string where, SqlConnection oCnn);
    DocsRecebidosItensResponse? Read(Entity.DBDocsRecebidosItens dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    DocsRecebidosItensResponse? Read(DBDocsRecebidosItens dbRec);
}

public partial class DocsRecebidosItens : IDocsRecebidosItensReader
{
    public DocsRecebidosItensResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocsRecebidosItensResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocsRecebidosItensResponse? Read(Entity.DBDocsRecebidosItens dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
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
        docsrecebidositens.Auditor = auditor;
        return docsrecebidositens;
    }

    public DocsRecebidosItensResponse? Read(DBDocsRecebidosItens dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
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
        docsrecebidositens.Auditor = auditor;
        return docsrecebidositens;
    }
}