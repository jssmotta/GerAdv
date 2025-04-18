#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusInstanciaReader
{
    StatusInstanciaResponse? Read(int id, SqlConnection oCnn);
    StatusInstanciaResponse? Read(string where, SqlConnection oCnn);
    StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    StatusInstanciaResponse? Read(DBStatusInstancia dbRec);
}

public partial class StatusInstancia : IStatusInstanciaReader
{
    public StatusInstanciaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusInstanciaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusInstanciaResponse? Read(Entity.DBStatusInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        statusinstancia.Auditor = auditor;
        return statusinstancia;
    }

    public StatusInstanciaResponse? Read(DBStatusInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        statusinstancia.Auditor = auditor;
        return statusinstancia;
    }
}