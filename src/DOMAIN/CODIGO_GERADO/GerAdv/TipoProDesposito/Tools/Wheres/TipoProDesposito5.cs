#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoProDespositoWhere
{
    TipoProDespositoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoProDesposito : ITipoProDespositoWhere
{
    public TipoProDespositoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoProDesposito(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipoprodesposito = new TipoProDespositoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoprodesposito;
    }
}