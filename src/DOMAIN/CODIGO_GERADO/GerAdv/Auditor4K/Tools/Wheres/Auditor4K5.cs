#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAuditor4KWhere
{
    Auditor4KResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Auditor4K : IAuditor4KWhere
{
    public Auditor4KResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAuditor4K(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var auditor4k = new Auditor4KResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return auditor4k;
    }
}