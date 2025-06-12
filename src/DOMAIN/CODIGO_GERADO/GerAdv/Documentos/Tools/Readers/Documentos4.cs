#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocumentosReader
{
    DocumentosResponse? Read(int id, MsiSqlConnection oCnn);
    DocumentosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DocumentosResponse? Read(Entity.DBDocumentos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DocumentosResponse? Read(DBDocumentos dbRec);
    DocumentosResponseAll? ReadAll(DBDocumentos dbRec, DataRow dr);
}

public partial class Documentos : IDocumentosReader
{
    public DocumentosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocumentos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DocumentosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocumentos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            documentos.Data = dbRec.FData;
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            documentos.Data = dbRec.FData;
        return documentos;
    }

    public DocumentosResponseAll? ReadAll(DBDocumentos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var documentos = new DocumentosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            documentos.Data = dbRec.FData;
        documentos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return documentos;
    }
}