#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IJusticaWhere
{
    JusticaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Justica : IJusticaWhere
{
    public JusticaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBJustica(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var justica = new JusticaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return justica;
    }
}