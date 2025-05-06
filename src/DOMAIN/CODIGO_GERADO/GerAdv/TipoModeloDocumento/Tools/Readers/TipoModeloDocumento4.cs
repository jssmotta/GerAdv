#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoReader
{
    TipoModeloDocumentoResponse? Read(int id, SqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(string where, SqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(Entity.DBTipoModeloDocumento dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    TipoModeloDocumentoResponse? Read(DBTipoModeloDocumento dbRec);
}

public partial class TipoModeloDocumento : ITipoModeloDocumentoReader
{
    public TipoModeloDocumentoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoModeloDocumentoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoModeloDocumentoResponse? Read(Entity.DBTipoModeloDocumento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipomodelodocumento = new TipoModeloDocumentoResponse
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
        tipomodelodocumento.Auditor = auditor;
        return tipomodelodocumento;
    }

    public TipoModeloDocumentoResponse? Read(DBTipoModeloDocumento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipomodelodocumento = new TipoModeloDocumentoResponse
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
        tipomodelodocumento.Auditor = auditor;
        return tipomodelodocumento;
    }
}