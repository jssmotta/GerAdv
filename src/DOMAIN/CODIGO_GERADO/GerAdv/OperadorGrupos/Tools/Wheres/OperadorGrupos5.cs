#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposWhere
{
    OperadorGruposResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class OperadorGrupos : IOperadorGruposWhere
{
    public OperadorGruposResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return operadorgrupos;
    }
}