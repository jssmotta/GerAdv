#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraStatusWhere
{
    PenhoraStatusResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class PenhoraStatus : IPenhoraStatusWhere
{
    public PenhoraStatusResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhoraStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var penhorastatus = new PenhoraStatusResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return penhorastatus;
    }
}