#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRitoWhere
{
    RitoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Rito : IRitoWhere
{
    public RitoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRito(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var rito = new RitoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return rito;
    }
}