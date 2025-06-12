#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesWhere
{
    PaisesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Paises : IPaisesWhere
{
    public PaisesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPaises(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var paises = new PaisesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return paises;
    }
}