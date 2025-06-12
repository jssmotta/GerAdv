#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusHTrabWhere
{
    StatusHTrabResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class StatusHTrab : IStatusHTrabWhere
{
    public StatusHTrabResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusHTrab(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var statushtrab = new StatusHTrabResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            ResID = dbRec.FResID,
        };
        return statushtrab;
    }
}