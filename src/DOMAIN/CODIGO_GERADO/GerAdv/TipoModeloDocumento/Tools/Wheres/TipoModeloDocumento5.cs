#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoModeloDocumentoWhere
{
    TipoModeloDocumentoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoModeloDocumento : ITipoModeloDocumentoWhere
{
    public TipoModeloDocumentoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoModeloDocumento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipomodelodocumento = new TipoModeloDocumentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipomodelodocumento;
    }
}