#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoRecursoReader
{
    TipoRecursoResponse? Read(int id, SqlConnection oCnn);
    TipoRecursoResponse? Read(string where, SqlConnection oCnn);
    TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    TipoRecursoResponse? Read(DBTipoRecurso dbRec);
}

public partial class TipoRecurso : ITipoRecursoReader
{
    public TipoRecursoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoRecurso(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoRecursoResponse? Read(Entity.DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        tiporecurso.Auditor = auditor;
        return tiporecurso;
    }

    public TipoRecursoResponse? Read(DBTipoRecurso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tiporecurso = new TipoRecursoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        tiporecurso.Auditor = auditor;
        return tiporecurso;
    }
}