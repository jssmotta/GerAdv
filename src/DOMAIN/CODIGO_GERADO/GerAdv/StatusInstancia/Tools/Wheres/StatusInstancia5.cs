#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusInstanciaWhere
{
    StatusInstanciaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class StatusInstancia : IStatusInstanciaWhere
{
    public StatusInstanciaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusinstancia;
    }
}