#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoContatoCRMWhere
{
    TipoContatoCRMResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoContatoCRM : ITipoContatoCRMWhere
{
    public TipoContatoCRMResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoContatoCRM(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipocontatocrm = new TipoContatoCRMResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocontatocrm;
    }
}