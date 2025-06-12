#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoWhere
{
    GUTTipoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class GUTTipo : IGUTTipoWhere
{
    public GUTTipoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTTipo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var guttipo = new GUTTipoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Ordem = dbRec.FOrdem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return guttipo;
    }
}