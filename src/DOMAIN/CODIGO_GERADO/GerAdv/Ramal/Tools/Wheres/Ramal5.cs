#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRamalWhere
{
    RamalResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Ramal : IRamalWhere
{
    public RamalResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRamal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var ramal = new RamalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
        };
        return ramal;
    }
}