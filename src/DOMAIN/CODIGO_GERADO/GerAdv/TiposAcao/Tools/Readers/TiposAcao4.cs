#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITiposAcaoReader
{
    TiposAcaoResponse? Read(int id, SqlConnection oCnn);
    TiposAcaoResponse? Read(string where, SqlConnection oCnn);
    TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    TiposAcaoResponse? Read(DBTiposAcao dbRec);
}

public partial class TiposAcao : ITiposAcaoReader
{
    public TiposAcaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTiposAcao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TiposAcaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTiposAcao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TiposAcaoResponse? Read(Entity.DBTiposAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
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
        tiposacao.Auditor = auditor;
        return tiposacao;
    }

    public TiposAcaoResponse? Read(DBTiposAcao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiposacao = new TiposAcaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Inativo = dbRec.FInativo,
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
        tiposacao.Auditor = auditor;
        return tiposacao;
    }
}