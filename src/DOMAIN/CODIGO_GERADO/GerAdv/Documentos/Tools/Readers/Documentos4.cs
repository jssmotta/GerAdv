#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocumentosReader
{
    DocumentosResponse? Read(int id, SqlConnection oCnn);
    DocumentosResponse? Read(string where, SqlConnection oCnn);
    DocumentosResponse? Read(Entity.DBDocumentos dbRec);
    DocumentosResponse? Read(DBDocumentos dbRec);
}

public partial class Documentos : IDocumentosReader
{
    public DocumentosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocumentos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocumentosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocumentos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocumentosResponse? Read(Entity.DBDocumentos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var documentos = new DocumentosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            documentos.Data = dbRec.FData;
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
        documentos.Auditor = auditor;
        return documentos;
    }

    public DocumentosResponse? Read(DBDocumentos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var documentos = new DocumentosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            documentos.Data = dbRec.FData;
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
        documentos.Auditor = auditor;
        return documentos;
    }
}