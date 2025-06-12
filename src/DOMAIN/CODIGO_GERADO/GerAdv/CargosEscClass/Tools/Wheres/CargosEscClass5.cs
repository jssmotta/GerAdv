#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassWhere
{
    CargosEscClassResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class CargosEscClass : ICargosEscClassWhere
{
    public CargosEscClassResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEscClass(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var cargosescclass = new CargosEscClassResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosescclass;
    }
}